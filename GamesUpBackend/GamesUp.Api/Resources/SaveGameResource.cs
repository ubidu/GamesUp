using System.ComponentModel.DataAnnotations;

namespace GamesUp.Resources;

public class SaveGameResource
{
    [Required] [MaxLength(50)] public string Name { get; set; }
    [Required] public string Description { get; set; }
    public string CoverPath { get; set; }
    [Required] public string Category { get; set; }
    [Required] public string ReleaseDate { get; set; }
    [Required] public string Platform { get; set; }
    [Required] public string Developer { get; set; }
    [Required] public string Publisher { get; set; }
}