using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using BeavertonUV.Data;
using BeavertonUV.Models;

namespace BeavertonUV.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly BeavertonUVContext _context;

        // When model creating, page links with the data shouce.
        public DetailsModel(BeavertonUVContext context)
        {
            _context = context;
        }

        // kz: Scope of Student? Is it used only at x.cshtml?
        [BindProperty]
        public Student Student { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

         var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            Student = student;

            return Page();
        }
    }
}
