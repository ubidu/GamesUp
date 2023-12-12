namespace GamesUp.Models;

public class UserList
{
    public int Id { get; set; }
    public string Name { get; set; } // Nazwa listy
    public string UserId { get; set; } // Klucz obcy do użytkownika
    public List<Game> Games { get; set; } = new List<Game>(); // Nawigacja do gier w liście
}