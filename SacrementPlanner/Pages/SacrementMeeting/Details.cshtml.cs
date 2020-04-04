using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Data;
using SacrementPlanner.Models;

namespace SacrementPlanner.Pages.SacrementMeeting
{
    public class DetailsModel : PageModel
    {
        private readonly SacrementPlanner.Data.SacrementPlannerContext _context;

        public DetailsModel(SacrementPlanner.Data.SacrementPlannerContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
