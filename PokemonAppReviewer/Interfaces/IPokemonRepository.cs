using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
}