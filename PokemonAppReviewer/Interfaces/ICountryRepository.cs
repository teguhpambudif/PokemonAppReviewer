using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();
    Country GetCountry(int id);
    Country GetCountryByOwnerId(int ownerId);
    ICollection<Owner> GetOwnersByCountryId(int countryId);
    bool CountryExists(int id);
}