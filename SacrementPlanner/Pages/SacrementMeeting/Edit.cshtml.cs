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

namespace SacrementPlanner.Pages.SacrementMeeting
{
    public class EditModel : PageModel
    {
        private readonly SacrementPlanner.Data.SacrementPlannerContext _context;

        public EditModel(SacrementPlanner.Data.SacrementPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SacrementMeetings SacrementMeetings { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SacrementMeetings = await _context.SacrementMeetings
                .Include(s => s.MembersName).FirstOrDefaultAsync(m => m.SacrementMeetingsId == id);

            if (SacrementMeetings == null)
            {
                return NotFound();
            }
           ViewData["MembersId"] = new SelectList(_context.Members, "MembersId", "MembersId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SacrementMeetings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SacrementMeetingsExists(SacrementMeetings.SacrementMeetingsId))
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

        private bool SacrementMeetingsExists(int id)
        {
            return _context.SacrementMeetings.Any(e => e.SacrementMeetingsId == id);
        }
    }
}
