using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAppReviewer.Data;
using PokemonAppReviewer.dto;
using PokemonAppReviewer.Interfaces;
using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Controller;
[Route("api/[controller]")]
[ApiController]
public class ReviewerController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IReviewerRepository _reviewerRepository;
    private readonly IMapper _mapper;

    public ReviewerController(IReviewerRepository reviewerRepository,IMapper mapper)
    {
        _reviewerRepository = reviewerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
    public IActionResult Reviewers()
    {
        var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.Reviewers());
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(reviewers);
    }

    [HttpGet("{reviewerId}")]
    [ProducesResponseType(200, Type = typeof(Reviewer))]
    [ProducesResponseType(400)]
    public IActionResult GetReviewer(int reviewerId)
    {
        if (!_reviewerRepository.ReviewerExist(reviewerId))
        {
            return NotFound();
        }

        var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(reviewer);
    }
}