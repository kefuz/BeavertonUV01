using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeavertonUV.Data;
using BeavertonUV.Models;

namespace BeavertonUV.Pages.kzInstructor
{
    public class IndexModel : PageModel
    {
        private readonly BeavertonUV.Data.BeavertonUVContext _context;

        public IndexModel(BeavertonUV.Data.BeavertonUVContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Instructors != null)
            {
                Instructor = await _context.Instructors.ToListAsync();
            }
        }
    }
}
