using Microsoft.AspNetCore.Identity;

namespace SuperEeveeDex.Data.Models;

public class Trainer : IdentityUser {
    public string? TrainerName { get; set; }
    
}