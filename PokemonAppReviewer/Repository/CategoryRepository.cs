using PokemonAppReviewer.Data;
using PokemonAppReviewer.Interfaces;
using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }
    
    public ICollection<Category> GetCategories()
    {
        return _context.Categories.OrderBy(c => c.Id).ToList();
    }

    public Category GetCategory(int id)
    {
        return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
    }

    public ICollection<Pokemon> GetPokemonByCategoryId(int categoryId)
    {
        return _context.PokemonCategories.Where(e=>e.CategoryId == categoryId).Select(c=>c.Pokemon).ToList();
    }

    public bool CategoryExists(int id)
    {
        return _context.Categories.Any(c => c.Id == id);
    }

    public bool CreateCategory(Category category)
    {
        // there are 2 type of state. connected and disconnected(EntityState.Added)
        _context.Add(category); // this works a change tracker
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}