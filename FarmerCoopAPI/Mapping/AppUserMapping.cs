using AutoMapper;
using DtoLayer.AppUserDto;
using DtoLayer.PostDto;
using EntityLayer.Concrete;

namespace FarmerCoopAPI.Mapping
{
	public class AppUserMapping : Profile
	{
        public AppUserMapping()
        {
			CreateMap<AppUser, ResultAppUserDto>().ReverseMap();
			//CreateMap<AppUser, ResultAppUserDto>().ReverseMap()
			//	.ForMember(e=>e.Id, o =>o.MapFrom(d=>d.Id))
			//	.ForMember(e => e.Name, o => o.MapFrom(d => d.Name))
			//	.ForMember(e => e.Surname, o => o.MapFrom(d => d.Surname))
			//	;
		}
    }
}
