using AutoMapper;
using PokemonAppReviewer.Data;
using PokemonAppReviewer.Interfaces;
using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Repository;

public class ReviewerRepository : IReviewerRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewerRepository(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public bool ReviewerExist(int reviewerId)
    {
        return _context.Reviewers.Any(r => r.Id==reviewerId);
    }

    public IEnumerable<Reviewer> Reviewers()
    {
        return _context.Reviewers.OrderBy(r => r.Id).ToList();
    }

    public Reviewer GetReviewer(int reviewerId)
    {
        return _context.Reviewers.Where(r => r.Id == reviewerId).FirstOrDefault();
    }

    public ICollection<Review> GetReviewsByReviewerId(int reviewerId)
    {
        return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
    }
    
}