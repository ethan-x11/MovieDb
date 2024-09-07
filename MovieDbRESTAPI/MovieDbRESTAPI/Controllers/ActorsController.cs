using IMDbRESTAPI.CustomExceptions;
using IMDbRESTAPI.Helper;
using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IMDbRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_actorService.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseMessageHandler.ErrorObject(ex.Message));
            }
        }

        [HttpGet("{id:int:min(0)}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_actorService.Get(id));
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseMessageHandler.ErrorObject(ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActorRequest actorRequest)
        {
            try
            {
                var actorId = _actorService.Create(actorRequest);
                return StatusCode(StatusCodes.Status201Created, ResponseMessageHandler.SuccessObject(actorId, "Actor Created Successfully!"));
            }
            catch (EmptyDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseMessageHandler.ErrorObject(ex.Message));
            }
        }

        [HttpPut("{id:int:min(0)}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ActorRequest actorRequest)
        {
            try
            {
                _actorService.Update(id, actorRequest);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Actor {id} Updated Successfully!"));
            }
            catch (EmptyDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseMessageHandler.ErrorObject(ex.Message));
            }
        }

        [HttpDelete("{id:int:min(0)}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _actorService.Delete(id);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Actor {id} Deleted Successfully!"));
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseMessageHandler.ErrorObject(ex.Message));
            }
        }
    }
}
