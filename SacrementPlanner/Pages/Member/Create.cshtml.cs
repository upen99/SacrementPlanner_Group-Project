using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacrementPlanner.Data;
using SacrementPlanner.Models;

namespace SacrementPlanner.Pages.Member
{
    public class CreateModel : PageModel
    {
        private readonly SacrementPlanner.Data.SacrementPlannerContext _context;

        public CreateModel(SacrementPlanner.Data.SacrementPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Members Members { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Members.Add(Members);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}