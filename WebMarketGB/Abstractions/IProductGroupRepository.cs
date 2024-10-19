using WebMarketGB.DTO;
using WebMarketGB.Models;

namespace WebMarketGB.Abstractions
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDTO> GetProductsGroup();
        int AddProductGroup(ProductGroupDTO productGroupDTO);
        string DeleteProductGroup(string name);
    }
}
