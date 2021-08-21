using Identity.Application.Vehicles;
using Identity.Domain;
using MediatR;
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
        [HttpGet("{username}")]
        [Authorize]
        public async Task<ActionResult<List<Vehicle>>> GetUserVehicles(string username, string predicate)
        {
            return await Mediator.Send(new ListVehicle.Query { Username = username, Predicate = predicate });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Unit>> Create(CreateVehicle.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Unit>> Edit(string id, EditVehicle.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

    }
}
