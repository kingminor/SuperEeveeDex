namespace SuperEeveeDex.Data.Models;

public class Ability
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? BattleEffect { get; set; }

    public List<Species> Species { get; set; } = new();
}