using AutoMapper;
using Sha.BaseService.Model.DTO;
using Sha.BaseService.Model.Entity;

namespace Sha.BaseService.Model.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<AddressCreate, t_Address>();
            CreateMap<AddressUpdate, t_Address>();
        }
    }
}
