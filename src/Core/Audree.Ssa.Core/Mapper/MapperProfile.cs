using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Core.ViewModel;
using AutoMapper;


namespace Audree.Ssa.Core.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            
            CreateMap<UOM,UOMViewmodel>().ReverseMap();
            CreateMap<Menu,MenuViewmodel>().ReverseMap();
            CreateMap<Country,CountryViewmodel>().ReverseMap();
            CreateMap<Material,MaterialViewmodel>().ReverseMap();
            CreateMap<Salutation, SalutationViewmodel>().ReverseMap();
            //CreateMap<Profile, ProfileViewmodel>().ReverseMap();
            CreateMap<Role, RoleViewmodel>().ReverseMap();
            CreateMap<ProfilesMaster, ProfilesMasterViewmodel>().ReverseMap();
            
        }
    }
}
