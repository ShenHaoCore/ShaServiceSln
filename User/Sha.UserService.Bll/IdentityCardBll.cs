using Microsoft.Extensions.Logging;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll.Common;
using Sha.UserService.Dal;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;

namespace Sha.UserService.Bll
{
    /// <summary>
    /// 身份证
    /// </summary>
    public class IdentityCardBll : UserServiceBll
    {
        private readonly IdentityCardDal dal;

        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="dal">数据访问层</param>
        public IdentityCardBll(ILogger<IdentityCardBll> logger, IdentityCardDal dal) : base(logger)
        {
            this.dal = dal;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">公民身份号码</param>
        /// <returns></returns>
        public t_IdentityCard GetByNumber(string number) => dal.GetByNumber(number);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public ResultModel<bool> Create(IdcardCreateParam param)
        {
            t_IdentityCard idcard = new t_IdentityCard();
            if (!this.dal.Create(idcard)) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<bool>(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
