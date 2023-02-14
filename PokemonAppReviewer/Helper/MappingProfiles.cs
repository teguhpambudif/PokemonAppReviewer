using AutoMapper;
using PokemonAppReviewer.dto;
using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Country, CountryDto>();
        CreateMap<Owner, OwnerDto>();
        CreateMap<Review, ReviewDto>();
    }
}