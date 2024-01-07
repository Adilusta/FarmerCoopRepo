using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CommentDto;
using DtoLayer.PostDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly ICommentService _commentService;
		private readonly IMapper _mapper;

		public CommentController(ICommentService commentService, IMapper mapper)
		{
			_commentService = commentService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CommentList()
		{
			var commentList = _commentService.GetAll();
			var values = _mapper.Map<List<ResultCommentDto>>(commentList);
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateComment(CreateCommentDto createCommentDto)
		{
			var value = _mapper.Map<Comment>(createCommentDto);
			_commentService.Insert(value);
			return Ok("Yorum eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteComment(int id)
		{
			var comment = _commentService.GetEntityByID(id);
			_commentService.Delete(comment);
			return Ok("Yorum silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetComment(int id)
		{
			var comment = _commentService.GetEntityByID(id);
			var value = _mapper.Map<ResultCommentDto>(comment);
			//var value = _categoryService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateComment(UpdateCommentDto updateCommentDto)
		{
			var comment = _mapper.Map<Comment>(updateCommentDto);
			_commentService.Update(comment);
			return Ok("Yorum Güncellendi");
		}
		[HttpGet("GetCommentListByAppUser/{userID}")]
		public IActionResult GetCommentListByAppUser(int userID)
		{
			var commentList = _commentService.GetCommentListByAppUser(userID);
			var value = _mapper.Map<List<GetCommentByAppUserDto>>(commentList);
			//var value = _categoryService.TGetById(id);
			return Ok(value);
		}
	}
}