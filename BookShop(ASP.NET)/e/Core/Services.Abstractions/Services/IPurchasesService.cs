using Services.Abstractions.Dto.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Services
{
    public interface IPurchasesService
    {
        Task<IEnumerable<PurchaseDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PurchaseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PurchaseDto> CreateAsync(CreatePurchaseDto model, CancellationToken cancellationToken = default);
        Task Update(UpdatePurchaseDto model, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
