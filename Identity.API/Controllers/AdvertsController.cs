using Identity.Application.Adverts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    public class AdvertsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List.AdsEnvelope>> List(int? limit,
            int? offset, bool isGoing, bool isHost, DateTime? startDate)
        {
            return await Mediator.Send(new List.Query(limit,
                offset, isHost, startDate));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AdDto>> Details(Guid id)
        {
            return await Mediator.Send(new DetailsAd.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateAd.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "IsAdvertCreator")]
        public async Task<ActionResult<Unit>> Edit(Guid id, EditAd.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "IsAdvertCreator")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new DeleteAd.Command { Id = id });
        }
    }
}
