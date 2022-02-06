using Domain.Entity;
using Domain.Repository;
using Services.Abstractions.Dto.Purchase;
using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class PurchasesService : IPurchasesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AutoMapper.ObjectMapper objectManager = AutoMapper.ObjectMapper.Instance;
        public PurchasesService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public async Task<PurchaseDto> CreateAsync(CreatePurchaseDto model, CancellationToken cancellationToken = default)
        {
            var book = await unitOfWork.PurchasesRepository.Create(objectManager.Mapper.Map<Purchase>(model));
            return objectManager.Mapper.Map<PurchaseDto>(book);
        }

        public async Task<PurchaseDto> Create(PurchaseDto model, CancellationToken cancellationToken = default)
        {
            var book = await unitOfWork.PurchasesRepository.Create(objectManager.Mapper.Map<Purchase>(model));
            return objectManager.Mapper.Map<PurchaseDto>(book);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await unitOfWork.PurchasesRepository.GetAsync(id);
            await unitOfWork.PurchasesRepository.Remove(result.Id);
        }

        public async Task<IEnumerable<PurchaseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var books = await unitOfWork.PurchasesRepository.GetAllAsync();
            return objectManager.Mapper.Map<IEnumerable<PurchaseDto>>(books).ToList();
        }

        public async Task<PurchaseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return objectManager.Mapper.Map<PurchaseDto>(await unitOfWork.PurchasesRepository.GetAsync(id));
        }

        public async Task Update(UpdatePurchaseDto model, CancellationToken cancellationToken = default)
        {
            var result = objectManager.Mapper.Map<Purchase>(model);
            await unitOfWork.PurchasesRepository.Update(result);
        }
    }
}
