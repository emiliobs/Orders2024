using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Repositories.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.Repositories.Implementations
{
    public class StatesRepository : GenericRepository<State>, IStatesRepository
    {
        private readonly DataContext _context;

        public StatesRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<ActionsResponse<State>> GetAsync(int id)
        {
            var state = await _context.States.Include(s => s.Cities).FirstOrDefaultAsync(s => s.Id == id);

            if (state is null)
            {
                return new ActionsResponse<State>
                {
                    WasSuccess = false,
                    Message = "Estado no Existe!"
                };
            };

            return new ActionsResponse<State>
            {
                WasSuccess = true,
                Result = state
            };
        }

        public override async Task<ActionsResponse<IEnumerable<State>>> GetAsync()
        {
            var states = await _context.States.Include(s => s.Cities).ToListAsync();

            return new ActionsResponse<IEnumerable<State>>
            {
                WasSuccess = true,
                Result = states
            };
        }


    }
}
