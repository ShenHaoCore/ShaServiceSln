using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Sha.Framework.Filter
{
    /// <summary>
    /// 全局路由前缀
    /// </summary>
    public class GlobalRoutePrefixFilter : IApplicationModelConvention
    {
        private readonly AttributeRouteModel prefix;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="templateProvider"></param>
        public GlobalRoutePrefixFilter(IRouteTemplateProvider templateProvider)
        {
            prefix = new AttributeRouteModel(templateProvider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                foreach (var selector in controller.Selectors)
                {
                    if (selector.AttributeRouteModel is null) { selector.AttributeRouteModel = prefix; }
                    if (selector.AttributeRouteModel is not null) { selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(prefix, selector.AttributeRouteModel); }
                }
            }
        }
    }
}
