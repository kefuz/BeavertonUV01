using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeavertonUV.Data;
using BeavertonUV.Models;

namespace BeavertonUV.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly BeavertonUV.Data.BeavertonUVContext _context;

        public CreateModel(BeavertonUV.Data.BeavertonUVContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
        ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
