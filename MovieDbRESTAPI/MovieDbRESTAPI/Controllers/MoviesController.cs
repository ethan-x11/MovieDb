using Firebase.Auth;
using Firebase.Storage;
using IMDbRESTAPI.CustomExceptions;
using IMDbRESTAPI.Helper;
using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.RequestModels.FilterRequests;
using IMDbRESTAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDbRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly string _firebaseBucket;
        private readonly string _firebaseDirectory;
        private readonly string _firebaseApiKey;

        public MoviesController(IMovieService movieService, IOptions<FirebaseAccountData> firebaseAccountData)
        {
            _movieService = movieService;
            _firebaseBucket = firebaseAccountData.Value.Bucket;
            _firebaseDirectory = firebaseAccountData.Value.Directory;
            _firebaseApiKey = firebaseAccountData.Value.APIKey;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] MovieFilterRequest movieFilterRequest)
        {
            try
            {
                return Ok(_movieService.Get(movieFilterRequest));
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
                return Ok(_movieService.Get(id));
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
        public IActionResult Create([FromBody] MovieRequest movieRequest)
        {
            try
            {
                var movieId = _movieService.Create(movieRequest);
                return StatusCode(StatusCodes.Status201Created, ResponseMessageHandler.SuccessObject(movieId, "Movie Created Successfully!"));
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

        [HttpPut("{id:int:min(0)}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MovieRequest movieRequest)
        {
            try
            {
                _movieService.Update(id, movieRequest);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Movie {id} Updated Successfully!"));
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
                _movieService.Delete(id);
                return Ok(ResponseMessageHandler.SuccessObject(id, $"Movie {id} Deleted Successfully!"));
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

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("File Not Selected!");

            var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseApiKey));
            var a = await auth.SignInAnonymouslyAsync();
            var cancellation = new CancellationTokenSource();

            var task = await new FirebaseStorage(
                _firebaseBucket,
                new FirebaseStorageOptions { AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken), ThrowOnCancel = true }
                )
                    .Child(_firebaseDirectory)
                    .Child(Guid.NewGuid().ToString() + ".jpg")
                    .PutAsync(file.OpenReadStream(), cancellation.Token);

            return Ok(task);
        }

    }
}
