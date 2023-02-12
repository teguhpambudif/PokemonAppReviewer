using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAppReviewer.dto;
using PokemonAppReviewer.Interfaces;
using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Controller;
[Route("api/[controller]")]
[ApiController]
public class CountryController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountryController(ICountryRepository countryRepository,IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    public IActionResult GetCountries()
    {
        var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(countries);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountry(int id)
    {
        if (!_countryRepository.CountryExists(id))
        {
            return NotFound();
        }

        var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(id));
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(country);
    }

    [HttpGet("/owners/{ownerId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountryByOwnerId(int ownerId)
    {
        var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwnerId(ownerId));
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(country);
    }

    [HttpGet("owners/{countryId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
    [ProducesResponseType(400)]
    public IActionResult GetOwnersByCountyId(int countryId)
    {
        var owners = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersByCountryId(countryId).ToList());
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        return Ok(owners);
    }
}