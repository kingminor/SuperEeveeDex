using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperEeveeDex.Data;
using SuperEeveeDex.Services;

namespace SuperEeveeDex.Pages;

public class TypeEffectivenessModel : PageModel
{
    private readonly EeveeDexContext _context;
    private readonly TypeService _typeService;

    public TypeEffectivenessModel(EeveeDexContext context, TypeService typeService)
    {
        _context = context;
        _typeService = typeService;
    }

    // Existing property for the full chart
    public List<Data.Models.TypeEffectiveness> TypeChart { get; set; } = new();

    // --- NEW PROPERTIES FOR THE CALCULATOR ---

    // 1. Dropdown Data: Holds the list of types for the <select> elements
    public SelectList TypeOptions { get; set; }

    // 2. Form Inputs: [BindProperty] connects these to the HTML form
    [BindProperty]
    public Guid SelectedAttackingTypeId { get; set; }

    [BindProperty]
    public Guid SelectedDefendingType1Id { get; set; }

    [BindProperty]
    public Guid? SelectedDefendingType2Id { get; set; } // Nullable in case they only have 1 type

    // 3. Output: To show the result
    public float? CalculatedResult { get; set; }
    public string ResultMessage { get; set; }


    public async Task OnGetAsync()
    {
        // Load the full chart (existing logic)
        TypeChart = await _context.TypeEffectivenesses
            .Include(te => te.AttackingType)
            .Include(te => te.DefendingType)
            .OrderBy(te => te.AttackingType.Name)
            .ThenBy(te => te.DefendingType.Name)
            .ToListAsync();

        // Load the dropdown options
        await LoadTypeOptions();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // 1. Create the list of defending types
        var defendingTypes = new List<Guid>();
        
        // Always add the first type
        defendingTypes.Add(SelectedDefendingType1Id);

        // Add the second type only if it was selected (and distinct from the first to avoid weird logic)
        if (SelectedDefendingType2Id.HasValue && SelectedDefendingType2Id != Guid.Empty)
        {
             defendingTypes.Add(SelectedDefendingType2Id.Value);
        }

        // 2. Call your existing service
        // Note: We wrap in try/catch in case a type combo doesn't exist in the DB
        try 
        {
            CalculatedResult = await _typeService.GetAttackEffectiveness(SelectedAttackingTypeId, defendingTypes);
            
            // formatting the message
            if(CalculatedResult > 1) ResultMessage = "It's super effective!";
            else if (CalculatedResult == 0) ResultMessage = "It has no effect...";
            else if (CalculatedResult < 1) ResultMessage = "It's not very effective...";
            else ResultMessage = "Regular damage.";
        }
        catch (Exception ex)
        {
            // Log error or handle missing data
            ResultMessage = "Error calculating effectiveness. Are all types valid?";
        }

        // 3. Reload data so the page (and the chart below) still renders correctly
        await OnGetAsync(); 
        
        return Page();
    }

    private async Task LoadTypeOptions()
    {
        // Get all types from the DB
        var types = await _context.Types.OrderBy(t => t.Name).ToListAsync();
        
        // Convert to SelectList (Value = Id, Text = Name)
        TypeOptions = new SelectList(types, "Id", "Name");
    }
}