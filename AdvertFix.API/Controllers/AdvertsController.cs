using AdvertFix.Data.Repository;
using AdvertFix.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertFix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertRepository _advertRepository;
        public AdvertsController(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
        // GET: api/<AdvertsController>
        [HttpGet]
        public IActionResult Get()
        {
            var adverts = _advertRepository.GetAllAdverts();
            return new OkObjectResult(adverts);
        }

        // GET api/<AdvertsController>/5
        [HttpGet("{id}",Name = "Get")]
        public IActionResult Get(int id)
        {
            var advert = _advertRepository.GetAdvertByID(id);
            return new OkObjectResult(advert);
        }

        // POST api/<AdvertsController>
        [HttpPost]
        public IActionResult Post([FromBody] Advert advert)
        {
            using (var scope = new TransactionScope())
            {
                _advertRepository.AddAdvert(advert);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = advert.Id, advert });
            }
        }

        // PUT api/<AdvertsController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Advert advert)
        {
            if (advert != null)
            {
                using(var scope = new TransactionScope())
                {
                    _advertRepository.UpdateAdvert(advert);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<AdvertsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _advertRepository.DeleteAdvert(id);
            return new OkResult();
        }
    }
}
