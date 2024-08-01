using Microsoft.AspNetCore.Mvc;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : GenericController<State>
    {
        private readonly IStateUnitOfWork _stateUnitOfWork;

        public StatesController(IGenericUnitOfWork<State> unitOfWork, IStateUnitOfWork stateUnitOfWork) : base(unitOfWork)
        {
            this._stateUnitOfWork = stateUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _stateUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }

            return BadRequest();

        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await this._stateUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }

            return NotFound();
        }
    }
}
