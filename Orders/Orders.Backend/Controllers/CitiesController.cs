using Microsoft.AspNetCore.Mvc;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : GenericController<City>
    {
        private readonly IGenericUnitOfWork<City> _unitOfWork;

        public CitiesController(IGenericUnitOfWork<City> unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


    }
}
