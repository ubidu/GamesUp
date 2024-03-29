﻿using System.ComponentModel.DataAnnotations;

namespace GamesUp.Authentication;

public class RegisterModel
{
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }
    
    
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
    
    
    [Required(ErrorMessage = "Username is required")]
    public string? Username { get; set; }
}