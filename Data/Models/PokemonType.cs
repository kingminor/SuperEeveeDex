namespace SuperEeveeDex.Data.Models;

public class PokemonType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    public List<Species> Species { get; set; } = new();
    
    public List<TypeEffectiveness> Attacking { get; set; } = new(); // How this type attacks others
    public List<TypeEffectiveness> Defending { get; set; } = new(); // How other types attack this
}
