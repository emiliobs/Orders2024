using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.Repositories.Interfaces
{
    public interface IStatesRepository
    {
        Task<ActionsResponse<State>> GetAsync(int id);
        Task<ActionsResponse<IEnumerable<State>>> GetAsync();
    }
}
