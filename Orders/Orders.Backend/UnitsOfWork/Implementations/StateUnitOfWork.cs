using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations
{
    public class StateUnitOfWork : GenericUnitOfWork<State>, IStateUnitOfWork
    {

        private readonly IStatesRepository _statesRepository;

        public StateUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : base(repository)
        {

            this._statesRepository = statesRepository;
        }

        public override async Task<ActionsResponse<IEnumerable<State>>> GetAsync() => await _statesRepository.GetAsync();

        public override async Task<ActionsResponse<State>> GetAsync(int id) => await _statesRepository.GetAsync(id);


    }
}
