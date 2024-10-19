using AutoMapper;
using WebMarketGB.DTO;
using WebMarketGB.Models;

namespace WebMarketGB.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            // используем маппинг. Название свойств entity совпадает с названиями свойств в DTO 
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDTO>().ReverseMap();
            CreateMap<Storage, StorageDTO>().ReverseMap();
            // ReverseMap для маппирования в обе стороны
        }
    }
}
