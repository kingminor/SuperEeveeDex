namespace SuperEeveeDex.Data.Models;

public class EvolutionChain
{
    public Guid Id { get; set; }

    public List<Species> Species { get; set; } = new();
}
