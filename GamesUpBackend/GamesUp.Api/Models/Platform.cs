namespace GamesUp.Models;

public class Platform
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string LogoPath { get; set; }
    public Manufacturer Manufacturer { get; set; }
}