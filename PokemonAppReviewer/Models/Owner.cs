namespace PokemonAppReviewer.Models;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gym { get; set; }
    public Country Country { get; set; } // because it is only contain one country assosiated with it
    public ICollection<PokemonOwner> PokemonOwners { get; set; }
}