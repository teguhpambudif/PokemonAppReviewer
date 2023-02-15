using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Interfaces;

public interface IReviewerRepository
{
    bool ReviewerExist(int reviewerId);
    IEnumerable<Reviewer> Reviewers();
    Reviewer GetReviewer(int reviewerId);
    ICollection<Review> GetReviewsByReviewerId(int reviewerId);
}