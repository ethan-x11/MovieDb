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
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_genreService.Get());
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
                return Ok(_genreService.Get(id));
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
        public IActionResult Create([FromBody] GenreRequest genreRequest)
        {
            try
            {
                var genreId = _genreService.Create(genreRequest);
                return StatusCode(StatusCodes.Status201Created, ResponseMessageHandler.SuccessObject(genreId, "Genre Created Successfully!"));
            }
            catch (EmptyDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (DuplicateDataException ex)
            {
                return BadRequest(ResponseMessageHandler.ErrorObject(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseMessageHandler.ErrorObject(ex.Message));
            }
        }

        [HttpPut("{id:int:min(0)}")]
        public IActionResult Update([FromRoute] int id, [FromBody] GenreRequest genreRequest)
        {
            try
            {
                _genreService.Update(id, genreRequest);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Genre {id} Updated Successfully!"));
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
                _genreService.Delete(id);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Genre {id} Deleted Successfully!"));
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
