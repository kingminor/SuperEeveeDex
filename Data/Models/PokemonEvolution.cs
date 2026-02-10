namespace SuperEeveeDex.Data.Models;

public class PokemonEvolution
{
    public Guid Id { get; set; }

    public Guid PreEvolvedSpeciesId { get; set; }
    public Species PreEvolvedSpecies { get; set; } = null!;

    public Guid EvolvedSpeciesId { get; set; }
    public Species EvolvedSpecies { get; set; } = null!;

    public string? TriggerType { get; set; } // e.g., "level-up", "use-item"
    public int? MinLevel { get; set; }
    public string? TimeOfDay { get; set; }
}
