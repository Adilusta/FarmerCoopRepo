using AutoMapper;
using DtoLayer.CommentDto;
using EntityLayer.Concrete;

namespace FarmerCoopAPI.Mapping
{
	public class CommentMapping : Profile
	{
        public CommentMapping()
        {
			CreateMap<Comment, ResultCommentDto>().ReverseMap();
			CreateMap<Comment, GetCommentDto>().ReverseMap();
			CreateMap<Comment, UpdateCommentDto>().ReverseMap();
			CreateMap<Comment, CreateCommentDto>().ReverseMap();
		}

    }
}
