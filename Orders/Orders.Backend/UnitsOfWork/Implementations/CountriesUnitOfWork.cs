using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations
{
    public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
    {
        private readonly IGenericRepository<Country> _repository;
        private readonly ICountryRepository _countryRepository;

        public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountryRepository countryRepository) : base(repository)
        {
            this._repository = repository;
            this._countryRepository = countryRepository;
        }

        public override async Task<ActionsResponse<Country>> GetAsync(int id) => await _countryRepository.GetAsync(id);

        public override async Task<ActionsResponse<IEnumerable<Country>>> GetAsync() => await _countryRepository.GetAsync();
    }
}
