using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.PostDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace FarmerCoopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class PostController : ControllerBase
	{
		private readonly IPostService _postService;
		private readonly IMapper _mapper;

		public PostController(IPostService postService, IMapper mapper)
		{
			_postService = postService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult PostList()
		{
			var postList = _postService.GetAll();
			var values = _mapper.Map<List<ResultPostDto>>(postList);
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreatePost(CreatePostDto createPostDto)
		{
			var value = _mapper.Map<Post>(createPostDto);
			_postService.Insert(value);
			return Ok("Gönderi eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeletePost(int id)
		{
			var post = _postService.GetEntityByID(id);
			_postService.Delete(post);
			return Ok("Gönderi silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetPost(int id)
		{
			var post = _postService.GetEntityByID(id);
			var value = _mapper.Map<ResultPostDto>(post);
			//var value = _categoryService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdatePost(UpdatePostDto updatePostDto)
		{
			var post = _mapper.Map<Post>(updatePostDto);
			_postService.Update(post);
			return Ok("Gönderi Güncellendi");
		}

		[HttpGet("PostListWithAppUser")]
		public IActionResult PostListWithAppUser()
		{
			var posts=_postService.TGetPostListWithAppUser();
			var values = _mapper.Map<List<ResultPostWithAppUserDto>>(posts);
			return Ok(values);
		}
		[HttpGet("PostWithAppUser/{postID}")]
		public IActionResult PostWithAppUser(int postID)
		{
			var post = _postService.TGetPostWithAppUserByPostID(postID);
			var values = _mapper.Map<ResultPostWithAppUserDto>(post);
			return Ok(values);
		}
		[HttpGet("PostWithAppUserAndComments/{postID}")]
		public IActionResult PostWithAppUserAndComments(int postID)
		{
			var post = _postService.GetPostWithAppUserAndCommentsByPostID(postID);
			var values = _mapper.Map<ResultPostWithAppUserAndCommentsDto>(post);
			return Ok(values);
			
		}
	}
}