using Autofac;
using Microsoft.AspNetCore.Mvc;
using Sha.UserService.Bll.Common;
using Sha.UserService.Dal.Common;

namespace Sha.UserService.Api.Common
{
    /// <summary>
    /// 自动注册模块
    /// </summary>
    public class AutofacRegisterModule : Autofac.Module
    {
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(t => typeof(ControllerBase).IsAssignableFrom(t) && t != typeof(ControllerBase)).PropertiesAutowired();
            builder.RegisterAssemblyTypes(typeof(UserServiceBll).Assembly).Where(t => typeof(UserServiceBll).IsAssignableFrom(t) && t != typeof(UserServiceBll)).PropertiesAutowired();
            builder.RegisterAssemblyTypes(typeof(UserServiceDal).Assembly).Where(t => typeof(UserServiceDal).IsAssignableFrom(t) && t != typeof(UserServiceDal)).PropertiesAutowired();
        }
    }
}
