using Services.Abstractions.Dto.StoreBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Services
{
    public interface IStoreBooksService
    {
        Task<IEnumerable<StoreBookDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<StoreBookDto>> Search(string srch);
        Task<IEnumerable<StoreBookDto>> GetAllAsync(Func<StoreBookDto, bool> predicate, CancellationToken cancellationToken = default);
        Task<StoreBookDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<StoreBookDto> CreateAsync(CreateStoreBookDto model, CancellationToken cancellationToken = default);
        Task UpdateAsync(UpdateStoreBookDto model, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
