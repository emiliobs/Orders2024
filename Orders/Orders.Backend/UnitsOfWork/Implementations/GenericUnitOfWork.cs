using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            this._repository = repository;
        }

        public virtual async Task<ActionsResponse<T>> AddAsync(T entity) => await _repository.AddAsync(entity);

        public virtual async Task<ActionsResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public virtual async Task<ActionsResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);

        public virtual async Task<ActionsResponse<IEnumerable<T>>> GetAsync() => await _repository.GetAsync();

        public virtual async Task<ActionsResponse<T>> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
    }
}