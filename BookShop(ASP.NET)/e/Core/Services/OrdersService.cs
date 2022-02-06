using Domain.Entity;
using Domain.Repository;
using Services.Abstractions.Dto.Order;
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
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AutoMapper.ObjectMapper objectManager = AutoMapper.ObjectMapper.Instance;
        public OrdersService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public async Task<OrderDto> CreateAsync(CreateOrderDto model, CancellationToken cancellationToken = default)
        {
            var book = await unitOfWork.OrdersRepository.Create(objectManager.Mapper.Map<Order>(model));
            return objectManager.Mapper.Map<OrderDto>(book);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await unitOfWork.OrdersRepository.GetAsync(id);
            await unitOfWork.OrdersRepository.Remove(result.Id);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var books = await unitOfWork.OrdersRepository.GetAllAsync();
            return objectManager.Mapper.Map<IEnumerable<OrderDto>>(books).ToList();
        }

        public async Task<OrderDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return objectManager.Mapper.Map<OrderDto>(await unitOfWork.OrdersRepository.GetAsync(id));
        }

        public async Task UpdateAsync(UpdateOrderDto model, CancellationToken cancellationToken = default)
        {
            var result = objectManager.Mapper.Map<Order>(model);
            await unitOfWork.OrdersRepository.Update(result);
        }
    }
}
