using AutoMapper;
using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.ResponseModels;

namespace IMDbRESTAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Actor, ActorResponse>().ReverseMap();
            CreateMap<Genre, GenreResponse>().ReverseMap();
            CreateMap<Movie, MovieResponse>().ReverseMap();
            CreateMap<Producer, ProducerResponse>().ReverseMap();
            CreateMap<Review, ReviewResponse>().ReverseMap();
            CreateMap<Actor, ActorRequest>().ReverseMap();
            CreateMap<Genre, GenreRequest>().ReverseMap();
            CreateMap<Movie, MovieRequest>().ReverseMap();
            CreateMap<Producer, ProducerRequest>().ReverseMap();
            CreateMap<Review, ReviewRequest>().ReverseMap();
        }
    }
}
