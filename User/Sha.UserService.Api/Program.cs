using Asp.Versioning;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sha.Framework.Cache;
using Sha.Framework.Common;
using Sha.Framework.Filter;
using Sha.Framework.Redis;
using Sha.Framework.Serilog;
using Sha.Framework.SqlSugar;
using Sha.Framework.Swagger;
using Sha.UserService.Api.Common;
using Sha.UserService.Model.Common;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
List<string> xmlFileNames = new() { $"{Assembly.GetExecutingAssembly().GetName().Name}.XML", $"{AppHelper.AssemblyName}.XML" };

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule<AutofacRegisterModule>(); });
builder.Host.AddSerilogSetup();

ServiceConfig? service = builder.Configuration.GetSection(ServiceConfig.KEY).Get<ServiceConfig>();
if (service == null) { throw new ArgumentNullException(nameof(service)); }

builder.Services.AddSingleton(new AppSettings(builder.Configuration));
builder.Services.AddAutoMapper(cfg => { cfg.AddProfile<AutoMapperConfig>(); });
builder.Services.AddCacheSetup();
builder.Services.AddRedisSetup();
builder.Services.AddSqlSugarSetup();
builder.Services.AddControllers(option =>
{
    option.Filters.Add<GlobalExceptionFilter>();
    option.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(service.PrefixName)));
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // 序列化时KEY为驼峰样式
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // 忽略循环引用
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; // 时间格式化
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
});
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("X-API-VERSION"), new MediaTypeApiVersionReader("VER"));
}).AddMvc().AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>()); // 属性注入必须
builder.Services.AddSwaggerSetup(xmlFileNames);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerMiddle();
}
app.UseSerilogMiddle();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
