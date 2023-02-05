namespace PokemonAppReviewer.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public ICollection<Review> Reviews { get; set; } // because it is many Review assosiated with it then using Icollec, it is almost the same as a list
}