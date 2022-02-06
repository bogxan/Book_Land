using Services.Abstractions.Dto.StoreBook;
using Services.Abstractions.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Services.Abstractions.Dto.Purchase;

namespace Services.Abstractions.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<OrderDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<OrderDto> CreateAsync(CreateOrderDto model, CancellationToken cancellationToken = default);
        Task UpdateAsync(UpdateOrderDto model, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
