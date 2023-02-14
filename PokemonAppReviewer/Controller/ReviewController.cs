using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAppReviewer.dto;
using PokemonAppReviewer.Interfaces;
using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Controller;
[Route("api/[controller]")]
[ApiController]
public class ReviewController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewController(IReviewRepository reviewRepository,IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
    public IActionResult Reviews()
    {
        var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.Reviews());
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(reviews);
    }

    [HttpGet("{reviewId}")]
    [ProducesResponseType(200, Type = typeof(Review))]
    [ProducesResponseType(400)]
    public IActionResult GetReview(int reviewId)
    {
        if (!_reviewRepository.ReviewExists(reviewId))
        {
            return NotFound();
        }

        var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(review);
    }

    [HttpGet("{pokeId}/reviews")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
    [ProducesResponseType(400)]
    public IActionResult GetReviewOfAPokemon(int pokeId)
    {
        if (!_reviewRepository.ReviewExists(pokeId))
        {
            return BadRequest();
        }

        var reviewPokemon = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewOfAPokemon(pokeId).ToList());
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(reviewPokemon);
    }
}