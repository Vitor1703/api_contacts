
using System.Net;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Apllication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll ()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //404
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //404
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //404
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromServices] IContactService _service, [FromBody] ContactsEntity hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(hotel);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new {id = result.Id})), result);
                } else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromServices] IContactService _service, [FromBody] ContactsEntity hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(hotel);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}