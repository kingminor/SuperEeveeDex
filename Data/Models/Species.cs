namespace SuperEeveeDex.Data.Models;

public class Species
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ushort PokedexNumber { get; set; }
    public ushort AttackStat  { get; set; }
    public ushort DefenseStat { get; set; }
    public ushort SpecialAttackStat  { get; set; }
    public ushort SpecialDefenseStat  { get; set; }
    public ushort SpeedStat { get; set; }
    public ushort HpStat { get; set; }
    public byte Generation { get; set; }
    public string Classification { get; set; } // e.g. Umbreon is the moonlight pokemon
    public bool IsMythical { get; set; } = false;
    public bool IsLegendary { get; set; } = false;
    public List<Image> Images { get; set; }
    public List<Sound> Sounds { get; set; }
    public List<PokemonType> Types { get; set; }
    public List<Ability> Abilities { get; set; } = new();
    // public EvolutionChain evolutionChain {get;set;}
    
    
    // Evolution
    public Guid? EvolutionChainId { get; set; } // Optional FK
    public EvolutionChain? EvolutionChain { get; set; }

    // Self-referencing for evolution tree
    public List<PokemonEvolution> Evolutions { get; set; } = new(); // species this evolves into
    public List<PokemonEvolution> PreEvolutions { get; set; } = new(); // species this evolved from
    
}