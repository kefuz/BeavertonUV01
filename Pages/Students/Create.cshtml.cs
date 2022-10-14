using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeavertonUV.Data;
using BeavertonUV.Models;

namespace BeavertonUV.Pages.Students
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
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Boolean _bv;
            var emptyStudent = new Student();

            // Try is on the model level not at database.
            _bv = await TryUpdateModelAsync<Student>(
                    emptyStudent,
                    "student",   
                    s => s.FirstMidName, 
                    s => s.LastName, 
                    s => s.EnrollmentDate);

             if (_bv ==true)
                { 
                    _context.Students.Add(Student);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }

             return Page();
 
        }
    }
}
