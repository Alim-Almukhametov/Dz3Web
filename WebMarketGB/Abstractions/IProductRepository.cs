using Microsoft.AspNetCore.Mvc;
using WebMarketGB.DTO;
using WebMarketGB.Models;

namespace WebMarketGB.Abstractions
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetProducts();
        int AddProduct(ProductDTO productDTO);
        string DeleteProduct(string name);
        string ChangePrice(string name, decimal price);

        string GetCacheStat();
    } 
}
