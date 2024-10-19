using WebMarketGB.Abstractions;
using WebMarketGB.DTO;
using WebMarketGB.Repository;

namespace WebMarketGB.Graph.Query
{
    public class Query
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStorageRepository _storageRepository;

        public Query(IProductRepository productRepository, IProductGroupRepository productGroupRepository, IStorageRepository storageRepository) 
        {
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
            _storageRepository = storageRepository;
        }

        // будет выдавать продкуты и группы продуктов
        public IEnumerable<ProductDTO> GetProducts() 
        {
           return _productRepository.GetProducts();
        }

        public IEnumerable<ProductGroupDTO> GetProductGroups([Service] ProductGroupRepository groupRepository) 
        {
           return _productGroupRepository.GetProductsGroup();
        }
        public IEnumerable<StorageDTO> GetStorages()
        {
            return _storageRepository.GetStorage();
        }
    }
}
