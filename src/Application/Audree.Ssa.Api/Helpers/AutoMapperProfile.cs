using Audree.Ssa.Api.DTOs;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;
using AutoMapper;
using User = Audree.Ssa.Infrastructure.Migrations.User;

namespace Audree.Ssa.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Material, MaterialDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<ProfilesMaster, ProfileMasterDTO>().ReverseMap();
            CreateMap<UOM, UOMDTO>().ReverseMap();
            CreateMap<Salutation, SalutationDTO>().ReverseMap();
            CreateMap<Core.Model.Admin.User, UserDTO>().ReverseMap();
            CreateMap<MenuMaster, MenuMasterDTO>().ReverseMap();
            CreateMap<ReasonForRejection, ReasonForRejectionDTO>().ReverseMap();
        }
    }
}