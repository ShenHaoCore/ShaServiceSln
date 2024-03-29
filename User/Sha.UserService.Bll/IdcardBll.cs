﻿using AutoMapper;
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
    public class IdcardBll : UserServiceBll
    {
        private readonly IdcardDal dal;

        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="dal">数据访问层</param>
        public IdcardBll(ILogger<IdcardBll> logger, IMapper mapper, IdcardDal dal) : base(logger, mapper)
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
        /// 分页查询
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public List<t_IdentityCard> QueryPage(IdcardQueryPage paramObj) => dal.QueryPage(paramObj);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="paramObj"></param>
        public ResultModel<bool> Create(IdcardCreate paramObj)
        {
            t_IdentityCard idcard = mapper.Map<t_IdentityCard>(paramObj);
            if (!dal.Create(idcard)) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<bool>(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
