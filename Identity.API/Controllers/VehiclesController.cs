using Identity.Application.Vehicles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    public class VehiclesController : BaseController
    {
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<VehicleDto>> Details(string id)
        {
            return await Mediator.Send(new DetailsVehicle.Query { Id = id });
        }
    }
}
