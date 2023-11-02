using ErrorOr;

namespace GamesUp.Models;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    private Category() {}

    private Category(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static ErrorOr<Category> Create(string name, Guid? id = null)
    {
        List<Error> errors = new();

        if (errors.Any())
        {
            return errors;
        }

        return new Category(id ?? Guid.NewGuid(), name);
    }
    
    
}