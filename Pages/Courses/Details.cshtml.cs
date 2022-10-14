using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeavertonUV.Data;
using BeavertonUV.Models;

namespace BeavertonUV.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly BeavertonUV.Data.BeavertonUVContext _context;

        public DetailsModel(BeavertonUV.Data.BeavertonUVContext context)
        {
            _context = context;
        }

      public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.CourseID == id);

            // var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);
            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
