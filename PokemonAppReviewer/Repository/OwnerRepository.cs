using AutoMapper;
using PokemonAppReviewer.Data;
using PokemonAppReviewer.Interfaces;
using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public OwnerRepository(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public bool OwnerExists(int ownerId)
    {
        return _context.Owners.Any(o=>o.Id==ownerId);
    }

    public ICollection<Owner> GetOwners()
    {
        return _context.Owners.OrderBy(o=>o.Id).ToList();
    }

    public Owner GetOwner(int ownerId)
    {
        return _context.Owners.Where(o=>o.Id==ownerId).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
    {
        return _context.PokemonOwners.OrderBy(po=>po.Pokemon.Id==pokeId).Select(o=>o.Owner).ToList();
    }

    public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
    {
        return _context.PokemonOwners.OrderBy(o=>o.Owner.Id==ownerId).Select(p=>p.Pokemon).ToList();
    }

    public bool CreateOwner(Owner owner)
    {
        _context.Add(owner);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
    
}