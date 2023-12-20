using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.PostDto;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			this._productService = productService;
			this._mapper = mapper;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			var productList = _productService.GetAll();
			var values = _mapper.Map<List<ResultProductDto>>(productList);
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);
			_productService.Insert(value);
			return Ok("Ürün eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var post = _productService.GetEntityByID(id);
			_productService.Delete(post);
			return Ok("Ürün silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var product = _productService.GetEntityByID(id);
			var value = _mapper.Map<ResultProductDto>(product);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			var product = _mapper.Map<Product>(updateProductDto);
			_productService.Update(product);
			return Ok("Ürün Güncellendi");
		}

		[HttpGet("ProductListWithAppUser")]
		public IActionResult ProductListWithAppUser()
		{
			var products = _productService.GetProductListWithAppUser();
			var values = _mapper.Map<List<ResultProductWithAppUserDto>>(products);
			return Ok(values);
		}
		[HttpGet("ProductWithAppUser/{productID}")]
		public IActionResult ProductWithAppUser(int productID)
		{
			var product = _productService.GetProductWithAppUserByProductID(productID);
			var values = _mapper.Map<ResultProductWithAppUserDto>(product);
			return Ok(values);
		}
	}
}
