using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Repositories.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.Repositories.Implementations
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<ActionsResponse<Country>> GetAsync(int id)
        {
            var country = await _context.Countries
                .OrderBy(c => c.Name)
                 .Include(c => c.States!)
                 .ThenInclude(s => s.Cities)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                return new ActionsResponse<Country>
                {
                    WasSuccess = false,
                    Message = "País no existe"
                };
            }

            return new ActionsResponse<Country>
            {
                WasSuccess = true,
                Result = country
            };


        }

        public override async Task<ActionsResponse<IEnumerable<Country>>> GetAsync()
        {
            var countries = await _context.Countries
                .OrderBy(x => x.Name)
                .Include(x => x.States!)
                .ThenInclude(s => s.Cities)
                .ToListAsync();

            return new ActionsResponse<IEnumerable<Country>>
            {
                WasSuccess = true,
                Result = countries
            };
        }
    }
}
