namespace GamesUp.Models;

public class UserList
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    // Klucz obcy do użytkownika
    public string UserId { get; set; }
    public User User { get; set; }

    // Lista gier przypisanych do listy
    public List<Game> Games { get; set; } = new List<Game>();
}