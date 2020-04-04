using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Data;
using SacrementPlanner.Models;

namespace SacrementPlanner.Pages.Member
{
    public class EditModel : PageModel
    {
        private readonly SacrementPlanner.Data.SacrementPlannerContext _context;

        public EditModel(SacrementPlanner.Data.SacrementPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Members Members { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Members = await _context.Members.FirstOrDefaultAsync(m => m.MembersId == id);

            if (Members == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Members).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersExists(Members.MembersId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MembersExists(int id)
        {
            return _context.Members.Any(e => e.MembersId == id);
        }
    }
}
