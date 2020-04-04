using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacrementPlanner.Data;
using SacrementPlanner.Models;

namespace SacrementPlanner.Pages.SacrementMeeting
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
        ViewData["MembersId"] = new SelectList(_context.Members, "MembersId", "MembersId");
            return Page();
        }

        [BindProperty]
        public SacrementMeetings SacrementMeetings { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SacrementMeetings.Add(SacrementMeetings);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}