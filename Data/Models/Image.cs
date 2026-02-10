namespace SuperEeveeDex.Data.Models;

public class Image {
    public Guid Id { get; set; }
    public string URL { get; set; } = null!;
    public bool IsMain { get; set; }
    public bool IsShiny { get; set; }
    
    public Guid SpeciesId { get; set; }
    public Species Species { get; set; } = null!;

}