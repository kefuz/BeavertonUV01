using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeavertonUV.Data;
using BeavertonUV.Models;

namespace BeavertonUV.Pages.Enrollments
{
    public class DetailsModel : PageModel
    {
        private readonly BeavertonUV.Data.BeavertonUVContext _context;

        public DetailsModel(BeavertonUV.Data.BeavertonUVContext context)
        {
            _context = context;
        }

      public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            else 
            {
                Enrollment = enrollment;
            }
            return Page();
        }
    }
}
