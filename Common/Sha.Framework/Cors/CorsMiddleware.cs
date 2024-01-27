﻿using Sha.Framework.Common;

namespace Sha.Framework.Cors
{
    /// <summary>
    /// 
    /// </summary>
    public static class CorsMiddleware
    {
        /// <summary>
        /// 使用CORS
        /// </summary>
        /// <param name="app"></param>
        public static void UseCorsMiddle(this IApplicationBuilder app)
        {
            string policyName = CorsConst.ORIGINS;
            var setting = AppSettingHelper.GetObject<CorsSetting>(CorsSetting.KEY);
            ArgumentNullException.ThrowIfNull(setting);
            if (setting.AllowAnyone) { policyName = CorsConst.ALLOWANY; }
            app.UseCors(policyName);
        }
    }
}
