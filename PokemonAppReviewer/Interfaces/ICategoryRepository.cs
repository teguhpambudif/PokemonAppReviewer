using PokemonAppReviewer.Models;

namespace PokemonAppReviewer.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Pokemon> GetPokemonByCategoryId(int categoryId);
    bool CategoryExists(int id);
    bool CreateCategory(Category category);
    bool Save();
}