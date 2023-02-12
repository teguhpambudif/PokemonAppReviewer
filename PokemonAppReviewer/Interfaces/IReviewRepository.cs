using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Interfaces;

public interface IReviewRepository
{
    bool ReviewExists(int reviewId);
    ICollection<Review> Reviews();
    Review GetReview(int reviewId);
    ICollection<Review> GetReviewOfAPokemon(int pokeId);
}