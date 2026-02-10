using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperEeveeDex.Data.Models;

namespace SuperEeveeDex.Data;

public class EeveeDexContext : IdentityDbContext<Trainer> {
    public EeveeDexContext(DbContextOptions<EeveeDexContext> options)
        : base(options) { }

    public DbSet<Species> Species { get; set; } = null!;
    public DbSet<Ability> Abilities { get; set; } = null!;
    public DbSet<PokemonType> Types { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<Sound> Sounds { get; set; } = null!;
    public DbSet<PokemonEvolution> PokemonEvolutions { get; set; } = null!;
    public DbSet<EvolutionChain> EvolutionChains { get; set; } = null!;
    public DbSet<TypeEffectiveness> TypeEffectivenesses { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        
        
        modelBuilder.Entity<TypeEffectiveness>()
            .HasIndex(te => new { te.AttackingTypeId, te.DefendingTypeId })
            .IsUnique();
        
        // =========
        // SEED DATA
        // TYPES
        var normal   = new Guid("00000000-0000-0000-0000-000000000001");
        var fire     = new Guid("00000000-0000-0000-0000-000000000002");
        var water    = new Guid("00000000-0000-0000-0000-000000000003");
        var electric = new Guid("00000000-0000-0000-0000-000000000004");
        var grass    = new Guid("00000000-0000-0000-0000-000000000005");
        var ice      = new Guid("00000000-0000-0000-0000-000000000006");
        var fighting = new Guid("00000000-0000-0000-0000-000000000007");
        var poison   = new Guid("00000000-0000-0000-0000-000000000008");
        var ground   = new Guid("00000000-0000-0000-0000-000000000009");
        var flying   = new Guid("00000000-0000-0000-0000-000000000010");
        var psychic  = new Guid("00000000-0000-0000-0000-000000000011");
        var bug      = new Guid("00000000-0000-0000-0000-000000000012");
        var rock     = new Guid("00000000-0000-0000-0000-000000000013");
        var ghost    = new Guid("00000000-0000-0000-0000-000000000014");
        var dragon   = new Guid("00000000-0000-0000-0000-000000000015");
        var dark     = new Guid("00000000-0000-0000-0000-000000000016");
        var steel    = new Guid("00000000-0000-0000-0000-000000000017");
        var fairy    = new Guid("00000000-0000-0000-0000-000000000018");
        
        modelBuilder.Entity<PokemonType>().HasData(
            new PokemonType { Id = normal,   Name = "normal" },
            new PokemonType { Id = fire,     Name = "fire" },
            new PokemonType { Id = water,    Name = "water" },
            new PokemonType { Id = electric, Name = "electric" },
            new PokemonType { Id = grass,    Name = "grass" },
            new PokemonType { Id = ice,      Name = "ice" },
            new PokemonType { Id = fighting, Name = "fighting" },
            new PokemonType { Id = poison,   Name = "poison" },
            new PokemonType { Id = ground,   Name = "ground" },
            new PokemonType { Id = flying,   Name = "flying" },
            new PokemonType { Id = psychic,  Name = "psychic" },
            new PokemonType { Id = bug,      Name = "bug" },
            new PokemonType { Id = rock,     Name = "rock" },
            new PokemonType { Id = ghost,    Name = "ghost" },
            new PokemonType { Id = dragon,   Name = "dragon" },
            new PokemonType { Id = dark,     Name = "dark" },
            new PokemonType { Id = steel,    Name = "steel" },
            new PokemonType { Id = fairy,    Name = "fairy" }
        );
        
        // SEED TYPE EFFECTIVENESS
        modelBuilder.Entity<TypeEffectiveness>().HasData(
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000001"),
                AttackingTypeId = normal,
                DefendingTypeId = rock,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000002"),
                AttackingTypeId = normal,
                DefendingTypeId = ghost,
                Multiplier = 0.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000003"),
                AttackingTypeId = normal,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000004"),
                AttackingTypeId = fire,
                DefendingTypeId = fire,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000005"),
                AttackingTypeId = fire,
                DefendingTypeId = water,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000006"),
                AttackingTypeId = fire,
                DefendingTypeId = grass,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000007"),
                AttackingTypeId = fire,
                DefendingTypeId = ice,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000008"),
                AttackingTypeId = fire,
                DefendingTypeId = bug,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000009"),
                AttackingTypeId = fire,
                DefendingTypeId = rock,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000010"),
                AttackingTypeId = fire,
                DefendingTypeId = dragon,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000011"),
                AttackingTypeId = fire,
                DefendingTypeId = steel,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000012"),
                AttackingTypeId = water,
                DefendingTypeId = fire,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000013"),
                AttackingTypeId = water,
                DefendingTypeId = water,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000014"),
                AttackingTypeId = water,
                DefendingTypeId = grass,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000015"),
                AttackingTypeId = water,
                DefendingTypeId = ground,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000016"),
                AttackingTypeId = water,
                DefendingTypeId = rock,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000017"),
                AttackingTypeId = water,
                DefendingTypeId = dragon,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000018"),
                AttackingTypeId = electric,
                DefendingTypeId = water,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000019"),
                AttackingTypeId = electric,
                DefendingTypeId = electric,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000020"),
                AttackingTypeId = electric,
                DefendingTypeId = grass,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000021"),
                AttackingTypeId = electric,
                DefendingTypeId = ground,
                Multiplier = 0.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000022"),
                AttackingTypeId = electric,
                DefendingTypeId = flying,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000023"),
                AttackingTypeId = electric,
                DefendingTypeId = dragon,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000024"),
                AttackingTypeId = grass,
                DefendingTypeId = fire,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000025"),
                AttackingTypeId = grass,
                DefendingTypeId = water,
                Multiplier = 2.0f,
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000026"),
                AttackingTypeId = grass,
                DefendingTypeId = grass,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000027"),
                AttackingTypeId = grass,
                DefendingTypeId = poison,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000028"),
                AttackingTypeId = grass,
                DefendingTypeId = ground,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000029"),
                AttackingTypeId = grass,
                DefendingTypeId = flying,
                Multiplier = 0.5f
            },
            new TypeEffectiveness()
            {
                Id = new Guid("10000000-0000-0000-0000-000000000030"),
                AttackingTypeId = grass,
                DefendingTypeId = bug,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000031"),
                AttackingTypeId = grass,
                DefendingTypeId = rock,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000032"),
                AttackingTypeId = grass,
                DefendingTypeId = dragon,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000033"),
                AttackingTypeId = grass,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000034"),
                AttackingTypeId = ice,
                DefendingTypeId = fire,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000035"),
                AttackingTypeId = ice,
                DefendingTypeId = water,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000036"),
                AttackingTypeId = ice,
                DefendingTypeId = grass,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000037"),
                AttackingTypeId = ice,
                DefendingTypeId = ice,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000038"),
                AttackingTypeId = ice,
                DefendingTypeId = ground,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000039"),
                AttackingTypeId = ice,
                DefendingTypeId = flying,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000041"),
                AttackingTypeId = ice,
                DefendingTypeId = dragon,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000042"),
                AttackingTypeId = ice,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000043"),
                AttackingTypeId = fighting,
                DefendingTypeId = normal,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000044"),
                AttackingTypeId = fighting,
                DefendingTypeId = ice,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000045"),
                AttackingTypeId = fighting,
                DefendingTypeId = poison,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000046"),
                AttackingTypeId = fighting,
                DefendingTypeId = flying,
                Multiplier = 0.5f,
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000047"),
                AttackingTypeId = fighting,
                DefendingTypeId = psychic,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000048"),
                AttackingTypeId = fighting,
                DefendingTypeId = bug,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000049"),
                AttackingTypeId = fighting,
                DefendingTypeId = rock,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000050"),
                AttackingTypeId = fighting,
                DefendingTypeId = dark,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000051"),
                AttackingTypeId = fighting,
                DefendingTypeId = steel,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000052"),
                AttackingTypeId = fighting,
                DefendingTypeId = fairy,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000053"),
                AttackingTypeId = poison,
                DefendingTypeId = grass,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000054"),
                AttackingTypeId = poison,
                DefendingTypeId = poison,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000055"),
                AttackingTypeId = poison,
                DefendingTypeId = ground,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000056"),
                AttackingTypeId = poison,
                DefendingTypeId = rock,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000057"),
                AttackingTypeId = poison,
                DefendingTypeId = ghost,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000058"),
                AttackingTypeId = poison,
                DefendingTypeId = steel,
                Multiplier = 0.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000059"),
                AttackingTypeId = poison,
                DefendingTypeId = fairy,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000060"),
                AttackingTypeId = ground,
                DefendingTypeId = fire,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000061"),
                AttackingTypeId = ground,
                DefendingTypeId = electric,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000062"),
                AttackingTypeId = ground,
                DefendingTypeId = grass,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000063"),
                AttackingTypeId = ground,
                DefendingTypeId = poison,
                Multiplier = 2.0f,
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000064"),
                AttackingTypeId = ground,
                DefendingTypeId = flying,
                Multiplier = 0.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000065"),
                AttackingTypeId = ground,
                DefendingTypeId = bug,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000066"),
                AttackingTypeId = ground,
                DefendingTypeId = rock,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000067"),
                AttackingTypeId = ground,
                DefendingTypeId = steel,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000068"),
                AttackingTypeId = flying,
                DefendingTypeId = electric,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000069"),
                AttackingTypeId = flying,
                DefendingTypeId = grass,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000070"),
                AttackingTypeId = flying,
                DefendingTypeId = fighting,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000071"),
                AttackingTypeId = flying,
                DefendingTypeId = bug,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000072"),
                AttackingTypeId = flying,
                DefendingTypeId = rock,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000073"),
                AttackingTypeId = flying,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000074"),
                AttackingTypeId = psychic,
                DefendingTypeId = fighting,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000075"),
                AttackingTypeId = psychic,
                DefendingTypeId = poison,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000076"),
                AttackingTypeId = psychic,
                DefendingTypeId = psychic,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000077"),
                AttackingTypeId = psychic,
                DefendingTypeId = dark,
                Multiplier = 0.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000078"),
                AttackingTypeId = psychic,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000079"),
                AttackingTypeId = bug,
                DefendingTypeId = fire,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000080"),
                AttackingTypeId = bug,
                DefendingTypeId = grass,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000081"),
                AttackingTypeId = bug,
                DefendingTypeId = fighting,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000082"),
                AttackingTypeId = bug,
                DefendingTypeId = poison,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000083"),
                AttackingTypeId = bug,
                DefendingTypeId = flying,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000084"),
                AttackingTypeId = bug,
                DefendingTypeId = psychic,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000085"),
                AttackingTypeId = bug,
                DefendingTypeId = ghost,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000086"),
                AttackingTypeId = bug,
                DefendingTypeId = dark,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000087"),
                AttackingTypeId = bug,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000088"),
                AttackingTypeId = bug,
                DefendingTypeId = fairy,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000089"),
                AttackingTypeId = rock,
                DefendingTypeId = fire,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000090"),
                AttackingTypeId = rock,
                DefendingTypeId = ice,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000091"),
                AttackingTypeId = rock,
                DefendingTypeId = fighting,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000092"),
                AttackingTypeId = rock,
                DefendingTypeId = ground,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000093"),
                AttackingTypeId = rock,
                DefendingTypeId = flying,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000094"),
                AttackingTypeId = rock,
                DefendingTypeId = bug,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000095"),
                AttackingTypeId = rock,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000096"),
                AttackingTypeId = ghost,
                DefendingTypeId = normal,
                Multiplier = 0.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000097"),
                AttackingTypeId = ghost,
                DefendingTypeId = psychic,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000098"),
                AttackingTypeId = ghost,
                DefendingTypeId = ghost,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000099"),
                AttackingTypeId = ghost,
                DefendingTypeId = dark,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000100"),
                AttackingTypeId = dragon,
                DefendingTypeId = dragon,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000101"),
                AttackingTypeId = dragon,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000102"),
                AttackingTypeId = dragon,
                DefendingTypeId = fairy,
                Multiplier = 0.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000103"),
                AttackingTypeId = dark,
                DefendingTypeId = fighting,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000104"),
                AttackingTypeId = dark,
                DefendingTypeId = psychic,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000105"),
                AttackingTypeId = dark,
                DefendingTypeId = ghost,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000106"),
                AttackingTypeId = dark,
                DefendingTypeId = dark,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000107"),
                AttackingTypeId = dark,
                DefendingTypeId = fairy,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000108"),
                AttackingTypeId = steel,
                DefendingTypeId = fire,
                Multiplier = 0.5f
            }
            , new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000109"),
                AttackingTypeId = steel,
                DefendingTypeId = water,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000110"),
                AttackingTypeId = steel,
                DefendingTypeId = electric,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000111"),
                AttackingTypeId = steel,
                DefendingTypeId = ice,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000112"),
                AttackingTypeId = steel,
                DefendingTypeId = rock,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000113"),
                AttackingTypeId = steel,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000114"),
                AttackingTypeId = steel,
                DefendingTypeId = fairy,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000115"),
                AttackingTypeId = fairy,
                DefendingTypeId = fire,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000116"),
                AttackingTypeId = fairy,
                DefendingTypeId = fighting,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000117"),
                AttackingTypeId = fairy,
                DefendingTypeId = poison,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000118"),
                AttackingTypeId = fairy,
                DefendingTypeId = dragon,
                Multiplier = 2.0f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000119"),
                AttackingTypeId = fairy,
                DefendingTypeId = fairy,
                Multiplier = 0.5f
            },
            new TypeEffectiveness
            {
                Id = new Guid("10000000-0000-0000-0000-000000000120"),
                AttackingTypeId = fairy,
                DefendingTypeId = steel,
                Multiplier = 0.5f
            }
        );

        
        // MANY TO MANY Species <-> Ability
        modelBuilder.Entity<Species>()
            .HasMany(s => s.Abilities)
            .WithMany(a => a.Species)
            .UsingEntity(j => j.ToTable("species_has_ability"));
        
        // MANY TO MANY SPECIES <-> TYPE
        modelBuilder.Entity<Species>()
            .HasMany(s => s.Types)
            .WithMany(t => t.Species)
            .UsingEntity(j => j.ToTable("species_has_type"));
            
        // POKEMON EVOLUTION SELF-REFERNCE
        modelBuilder.Entity<PokemonEvolution>()
            .HasOne(pe => pe.PreEvolvedSpecies)
            .WithMany(s => s.Evolutions)
            .HasForeignKey(pe => pe.PreEvolvedSpeciesId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<PokemonEvolution>()
            .HasOne(pe => pe.EvolvedSpecies)
            .WithMany(s => s.PreEvolutions)
            .HasForeignKey(pe => pe.EvolvedSpeciesId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<EvolutionChain>()
            .HasMany(ec => ec.Species)
            .WithOne(s => s.EvolutionChain)
            .HasForeignKey(s => s.EvolutionChainId);
        
        // TYPE EFFECTIVENESS
        modelBuilder.Entity<TypeEffectiveness>()
            .HasOne(te => te.AttackingType)
            .WithMany(t => t.Attacking)
            .HasForeignKey(te => te.AttackingTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TypeEffectiveness>()
            .HasOne(te => te.DefendingType)
            .WithMany(t => t.Defending)
            .HasForeignKey(te => te.DefendingTypeId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
