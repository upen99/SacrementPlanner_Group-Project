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
    public class IndexModel : PageModel
    {
        private readonly SacrementPlanner.Data.SacrementPlannerContext _context;

        public IndexModel(SacrementPlanner.Data.SacrementPlannerContext context)
        {
            _context = context;
        }

        public IList<SacrementMeetings> SacrementMeetings { get;set; }

        public async Task OnGetAsync()
        {
            SacrementMeetings = await _context.SacrementMeetings
                .Include(s => s.MembersName).ToListAsync();
        }
    }
}
