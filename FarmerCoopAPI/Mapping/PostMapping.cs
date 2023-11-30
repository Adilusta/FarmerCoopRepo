using AutoMapper;
using DtoLayer.PostDto;
using EntityLayer.Concrete;

namespace FarmerCoopAPI.Mapping
{
	public class PostMapping : Profile
	{
        public PostMapping()
        {
            CreateMap<Post, ResultPostDto>().ReverseMap();
            CreateMap<Post, GetPostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, ResultPostWithAppUserDto>().ReverseMap();
        }
    }
}
