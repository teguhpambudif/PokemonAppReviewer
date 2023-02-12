using AutoMapper;
using PokemonAppReviewer.Data;
using PokemonAppReviewer.Interfaces;
using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewRepository(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public bool ReviewExists(int reviewId)
    {
        return _context.Reviews.Any(r=>r.Id==reviewId);
    }

    public ICollection<Review> Reviews()
    {
        return _context.Reviews.OrderBy(r=>r.Id).ToList();
    }

    public Review GetReview(int reviewId)
    {
        return _context.Reviews.Where(r=>r.Id==reviewId).FirstOrDefault();
    }

    public ICollection<Review> GetReviewOfAPokemon(int pokeId)
    {
        return _context.Reviews.Where(r=>r.Pokemon.Id==pokeId).ToList();
    }
}