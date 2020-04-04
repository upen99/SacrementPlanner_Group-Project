using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Data;
using SacrementPlanner.Models;

namespace SacrementPlanner.Pages.Member
{
    public class DetailsModel : PageModel
    {
        private readonly SacrementPlanner.Data.SacrementPlannerContext _context;

        public DetailsModel(SacrementPlanner.Data.SacrementPlannerContext context)
        {
            _context = context;
        }

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
    }
}
