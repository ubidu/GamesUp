namespace GamesUp.Models;

public class Comment    // a do czego w ogole ta klasa
{
    public int ID { get; set; }
    public string Text { get; set; }
    public DateTime PublishDate { get; set; }
    public Game Game { get; set; }
    public User User { get; set; }
}