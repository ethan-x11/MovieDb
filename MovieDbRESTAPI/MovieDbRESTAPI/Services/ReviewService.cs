using AutoMapper;
using IMDbRESTAPI.CustomExceptions;
using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.ResponseModels;
using IMDbRESTAPI.Repositories.Interfaces;
using IMDbRESTAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDbRESTAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMovieService movieService, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _movieService = movieService;
            _mapper = mapper;
        }

        public IEnumerable<ReviewResponse> Get(int movieId)
        {
            _movieService.Get(movieId);

            try
            {
                return _mapper.Map<IEnumerable<ReviewResponse>>(_reviewRepository.Get(movieId).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Review Data!", ex);
            }
        }

        public ReviewResponse Get(int movieId, int id)
        {
            _movieService.Get(movieId);

            Review review;

            try
            {
                review = _reviewRepository.Get(movieId, id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Review Data!", ex);
            }

            if (review == null)
                throw new DataNotFoundException($"Review with Id {id}");

            return _mapper.Map<ReviewResponse>(review);

        }

        public int Create(int movieId, ReviewRequest reviewRequest)
        {
            _movieService.Get(movieId);


            if (string.IsNullOrWhiteSpace(reviewRequest.Message))
                throw new EmptyDataException("Review Message");

            var review = _mapper.Map<Review>(reviewRequest);
            review.MovieId = movieId;

            try
            {
                return _reviewRepository.Create(review);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Create Review!", ex);
            }
        }

        public void Update(int movieId, int id, ReviewRequest reviewRequest)
        {
            Get(movieId, id);

            if (string.IsNullOrWhiteSpace(reviewRequest.Message))
                throw new EmptyDataException("Review Message");

            var review = _mapper.Map<Review>(reviewRequest);
            review.MovieId = movieId;
            review.Id = id;

            try
            {
                _reviewRepository.Update(review);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Update Review!", ex);
            }
        }

        public void Delete(int movieId, int id)
        {
            Get(movieId, id);

            try
            {
                _reviewRepository.Delete(movieId, id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Delete Review!", ex);
            }
        }
    }
}
