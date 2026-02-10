using Microsoft.EntityFrameworkCore;
using SuperEeveeDex.Data;

namespace SuperEeveeDex.Services;

public class TypeService
{
    private readonly EeveeDexContext _context;
    
    public TypeService(EeveeDexContext context)
    {
        _context = context;
    }

    public async Task<float> GetAttackEffectiveness(Guid attackingType, List<Guid> defendingTypes)
    {
        float multiplier = 1.0f;
        foreach (var defendingType in defendingTypes)
        {
            multiplier = multiplier * await _context.TypeEffectivenesses
                .Where(te =>
                    te.AttackingTypeId == attackingType &&
                    te.DefendingTypeId == defendingType)
                .Select(te => te.Multiplier)
                .SingleAsync();
        }
        
        return multiplier;
    }
}