using WebMarketGB.Abstractions;
using WebMarketGB.DTO;
using WebMarketGB.Repository;

namespace WebMarketGB.Graph.Mutation
{
    public class Mutation(IProductRepository productRepository, IProductGroupRepository productGroupRepository, IStorageRepository storageRepository)
    {
        public int AddProduct(ProductDTO productDTO) => productRepository.AddProduct(productDTO);

        // что он здесь делает
        public int GetProductGroups([Service] IProductGroupRepository groupRepository, ProductGroupDTO productGroupDTO)
            => productGroupRepository.AddProductGroup(productGroupDTO);

        public int AddStorage(StorageDTO storageDTO) => storageRepository.AddStorage(storageDTO);
    }

}

