using WebMarketGB.DTO;
using WebMarketGB.Models;

namespace WebMarketGB.Abstractions
{
    public interface IStorageRepository
    {
        IEnumerable<StorageDTO> GetStorage();
        int AddStorage(StorageDTO productDTO);
        string DeleteStorage(int id);

    }
}
