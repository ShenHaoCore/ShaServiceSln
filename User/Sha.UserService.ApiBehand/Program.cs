using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sha.Framework.Cache;
using Sha.Framework.Common;
using Sha.Framework.Consul;
using Sha.Framework.Jwt;
using Sha.Framework.Redis;
using Sha.Framework.Serilog;
using Sha.Framework.SqlSugar;
using Sha.Framework.Swagger;
using Sha.UserService.ApiBehand.Common;
using Sha.UserService.Model.Common;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule<AutofacRegisterModule>(); });
builder.Host.AddSerilogSetup();

ServiceConfig? service = builder.Configuration.GetSection(ServiceConfig.KEY).Get<ServiceConfig>();
if (service == null) { throw new ArgumentNullException(nameof(service)); }

builder.Services.AddSingleton(new AppSettingHelper(builder.Configuration));
builder.Services.AddAutoMapper(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
builder.Services.AddCacheSetup();
builder.Services.AddRedisSetup();
builder.Services.AddSqlSugarSetup();
builder.Services.AddControllerSetup(service.PrefixName);
builder.Services.AddApiVersionSetup();
builder.Services.AddJwtSetup();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>()); // 属性注入必须
builder.Services.AddSwaggerSetup(new List<string>() { $"{Assembly.GetExecutingAssembly().GetName().Name}.XML", $"{ModelHelper.AssemblyName}.XML" });
builder.Services.AddConsulSetup();

var app = builder.Build();

if (app.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
app.UseSwaggerMiddle();
app.UseSerilogMiddle();
app.UseHealthCheckMiddle();
app.UseHttpsRedirection();
app.UseAuthentication(); // 认证中间件
app.UseAuthorization(); // 授权中间件
app.MapControllers();
app.Run();
