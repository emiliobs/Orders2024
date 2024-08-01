using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<ActionsResponse<Country>> GetAsync(int id);

        Task<ActionsResponse<IEnumerable<Country>>> GetAsync();
    }
}
