using Domain.Entity;
using Domain.Repository;
using Services.Abstractions.Dto.StoreBook;
using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class StoreBooksService : IStoreBooksService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AutoMapper.ObjectMapper objectManager = AutoMapper.ObjectMapper.Instance;
        public StoreBooksService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public async Task<StoreBookDto> CreateAsync(CreateStoreBookDto model, CancellationToken cancellationToken = default)
        {
            var book = await unitOfWork.StoreBooksRepository.Create(objectManager.Mapper.Map<StoreBook>(model));
            return objectManager.Mapper.Map<StoreBookDto>(book);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await unitOfWork.StoreBooksRepository.GetAsync(id);
            await unitOfWork.StoreBooksRepository.Remove(result.Id);
        }

        public async Task<IEnumerable<StoreBookDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var books = await unitOfWork.StoreBooksRepository.GetAllAsync();
            return objectManager.Mapper.Map<IEnumerable<StoreBookDto>>(books).ToList();
        }

        public async Task<IEnumerable<StoreBookDto>> GetAllAsync(Func<StoreBookDto, bool> predicate)
        {
            var result = objectManager.Mapper.Map<Func<StoreBook, bool>>(predicate);
            var books = await unitOfWork.StoreBooksRepository.GetAllAsync(result);
            return objectManager.Mapper.Map<IEnumerable<StoreBookDto>>(books).ToList();
        }


        public async Task<StoreBookDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return objectManager.Mapper.Map<StoreBookDto>(await unitOfWork.StoreBooksRepository.GetAsync(id));
        }

        public async Task UpdateAsync(UpdateStoreBookDto model, CancellationToken cancellationToken = default)
        {
            var result = objectManager.Mapper.Map<StoreBook>(model);
            await unitOfWork.StoreBooksRepository.Update(result);
        }

        public async Task Update(StoreBookDto model, CancellationToken cancellationToken = default)
        {
            var result = objectManager.Mapper.Map<StoreBook>(model);
            await unitOfWork.StoreBooksRepository.Update(result);
        }

        public async Task<IEnumerable<StoreBookDto>> GetAllAsync(Func<StoreBookDto, bool> predicate, CancellationToken cancellationToken = default)
        {
            var result = objectManager.Mapper.Map<Func<StoreBook, bool>>(predicate);
            var books = await unitOfWork.StoreBooksRepository.GetAllAsync(result);
            return objectManager.Mapper.Map<IEnumerable<StoreBookDto>>(books).ToList();
        }

        public async Task<IEnumerable<StoreBookDto>> Search(string srch)
        {
            var result = objectManager.Mapper.Map<List<StoreBookDto>>(await unitOfWork.StoreBooksRepository.Search(srch));
            return result;
        }
    }
}
