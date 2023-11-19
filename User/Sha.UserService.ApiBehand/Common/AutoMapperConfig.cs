using AutoMapper;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Request;

namespace Sha.UserService.ApiBehand.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<IdcardCreateRequest, IdcardCreateParam>();
        }
    }
}
