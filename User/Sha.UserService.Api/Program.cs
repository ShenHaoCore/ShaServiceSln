using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sha.Framework.Cache;
using Sha.Framework.Common;
using Sha.Framework.Consul;
using Sha.Framework.Cors;
using Sha.Framework.Jwt;
using Sha.Framework.RabbitMQ;
using Sha.Framework.Redis;
using Sha.Framework.Serilog;
using Sha.Framework.SqlSugar;
using Sha.Framework.Swagger;
using Sha.UserService.Api.Common;
using Sha.UserService.Model.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule<AutofacRegisterModule>(); });
builder.Host.AddSerilogSetup();

var setting = builder.Configuration.GetSection(ServiceSetting.KEY).Get<ServiceSetting>();
ArgumentNullException.ThrowIfNull(setting);
List<string> xmlNames = [$"{ServiceHelper.AssemblyName}.XML", $"{ModelHelper.AssemblyName}.XML", $"{FrameworkHelper.AssemblyName}.XML"];

builder.Services.AddSingleton(new AppSettingHelper(builder.Configuration));
builder.Services.AddAutoMapper(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
builder.Services.AddCacheSetup();
builder.Services.AddRedisSetup();
builder.Services.AddRabbitMQSetup();
builder.Services.AddSqlSugarSetup();
builder.Services.AddControllerSetup(setting.PrefixName);
builder.Services.AddApiVersionSetup();
builder.Services.AddCorsSetup();
builder.Services.AddJwtSetup();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>()); // 属性注入必须
builder.Services.AddSwaggerSetup(xmlNames);
builder.Services.AddConsulSetup();

var app = builder.Build();

if (app.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
app.UseSwaggerMiddle();
app.UseSerilogMiddle();
app.UseHealthCheckMiddle();
app.UseCorsMiddle();
app.UseHttpsRedirection();
app.UseAuthentication(); // 认证中间件
app.UseAuthorization(); // 授权中间件
app.MapControllers();
app.Run();
