using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Interfaces;

public interface IOwnerRepository
{
    bool OwnerExists(int ownerId);
    ICollection<Owner> GetOwners();
    Owner GetOwner(int ownerId);
    ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
    ICollection<Pokemon> GetPokemonByOwner(int ownerId);
    bool CreateOwner(Owner owner);
    bool Save();
}