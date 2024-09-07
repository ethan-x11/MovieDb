using IMDbRESTAPI.CustomExceptions;
using IMDbRESTAPI.Helper;
using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IMDbRESTAPI.Controllers
{
    [Route("api/movies/{movieId:int:min(0)}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Get([FromRoute] int movieId)
        {
            try
            {
                return Ok(_reviewService.Get(movieId));
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

        [HttpGet("{id:int:min(0)}")]
        public IActionResult Get([FromRoute] int movieId, [FromRoute] int id)
        {
            try
            {
                return Ok(_reviewService.Get(movieId, id));
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
        public IActionResult Create([FromRoute] int movieId, [FromBody] ReviewRequest reviewRequest)
        {
            try
            {
                var reviewId = _reviewService.Create(movieId, reviewRequest);
                return StatusCode(StatusCodes.Status201Created, ResponseMessageHandler.SuccessObject(reviewId, "Review Created Successfully!"));
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ResponseMessageHandler.ErrorObject(ex.Message));
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
        public IActionResult Update([FromRoute] int movieId, [FromRoute] int id, [FromBody] ReviewRequest reviewRequest)
        {
            try
            {
                _reviewService.Update(movieId, id, reviewRequest);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Review {id} of Movie {movieId} updated Successfully!"));
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
        public IActionResult Delete([FromRoute] int movieId, [FromRoute] int id)
        {
            try
            {
                _reviewService.Delete(movieId, id);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Review {id} of movie {movieId} deleted Successfully!"));
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
