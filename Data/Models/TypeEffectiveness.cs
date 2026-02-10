namespace SuperEeveeDex.Data.Models;

public class TypeEffectiveness
{
    public Guid Id { get; set; }
    public Guid AttackingTypeId { get; set; }
    public PokemonType AttackingType { get; set; } = null!;
    public Guid DefendingTypeId { get; set; }
    public PokemonType DefendingType { get; set; } = null!;
    public float Multiplier { get; set; }
}

