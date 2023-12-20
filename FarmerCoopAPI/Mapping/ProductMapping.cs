using AutoMapper;
using DtoLayer.PostDto;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;

namespace FarmerCoopAPI.Mapping
{
	public class ProductMapping : Profile
	{
        public ProductMapping()
        {
			CreateMap<Product, ResultProductDto>().ReverseMap();
			CreateMap<Product, GetProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductWithAppUserDto>().ReverseMap();
		}
    }
}
