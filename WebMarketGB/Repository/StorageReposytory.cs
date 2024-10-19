using AutoMapper;
using HotChocolate.Utilities;
using WebMarketGB.Abstractions;
using WebMarketGB.Data;
using WebMarketGB.DTO;
using WebMarketGB.Models;

namespace WebMarketGB.Repository
{
    public class StorageReposytory : IStorageRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public StorageReposytory(Context context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }



        public int AddStorage(StorageDTO storageDTO)
        {
            using (_context)
            {
                if (_context.Storages.Any(s => s.Id == storageDTO.Id))
                {
                    throw new NotImplementedException("Склад с таким ID уже существет");
                }

                var entity = _mapper.Map<Storage>(storageDTO);
                _context.Storages.Add(entity);
                _context.SaveChanges();
                return storageDTO.Id;
            }
        }

        public string DeleteStorage(int id)
        {

            using (_context)
            {
                if (!_context.Storages.Any(s=>s.Id==id))
                {
                    throw new NotImplementedException("Склад с таким ID не найден");
                }
                _context.Storages.Remove(_context.Storages.Find(id));
                _context.SaveChanges();
                return $"Склад с ID: {id} - удалён";
            }
        }

        public IEnumerable<StorageDTO> GetStorage()
        {
            using (_context)
            {
                var listDTO = _context.Storages.Select(_mapper.Map<StorageDTO>);
                return listDTO.ToList();
            }

        }
    }
}
