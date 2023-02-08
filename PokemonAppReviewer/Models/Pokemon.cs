namespace PokemonAppReviewer.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<Review> Reviews { get; set; } // because it is many Review assosiated with it then using Icollec, it is almost the same as a list
    public ICollection<PokemonOwner> PokemonOwners { get; set; }
    public ICollection<PokemonCategory> PokemonCategories { get; set; }
}