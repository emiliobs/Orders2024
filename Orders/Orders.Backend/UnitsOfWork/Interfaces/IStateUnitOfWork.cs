using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Interfaces
{
    public interface IStateUnitOfWork
    {
        Task<ActionsResponse<State>> GetAsync(int id);

        Task<ActionsResponse<IEnumerable<State>>> GetAsync();
    }
}
