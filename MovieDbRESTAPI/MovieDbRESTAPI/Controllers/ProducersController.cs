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
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_producerService.Get());
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
                return Ok(_producerService.Get(id));
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
        public IActionResult Create([FromBody] ProducerRequest producerRequest)
        {
            try
            {
                var producerId = _producerService.Create(producerRequest);
                return StatusCode(StatusCodes.Status201Created, ResponseMessageHandler.SuccessObject(producerId, "Producer Created Successfully!"));
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
        public IActionResult Update([FromRoute] int id, [FromBody] ProducerRequest producerRequest)
        {
            try
            {
                _producerService.Update(id, producerRequest);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Producer {id} Updated Successfully!"));
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
                _producerService.Delete(id);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Producer {id} Deleted Successfully!"));
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
