using AutoMapper;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;

namespace MoviesAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenreDto, Genre>()
                .ReverseMap();

            CreateMap<GenreCreationDto, Genre>();
        }
    }
}