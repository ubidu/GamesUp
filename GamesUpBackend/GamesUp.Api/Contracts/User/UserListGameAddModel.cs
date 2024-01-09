namespace GamesUp.Contracts.User;

public class UserListGameAddModel
{
    public string ListName { get; set; } // Nazwa listy, do której dodajesz grę
    public Guid GameId { get; set; } // Identyfikator gry, którą chcesz dodać do listy
}