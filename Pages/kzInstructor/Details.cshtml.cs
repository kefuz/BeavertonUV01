﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly BeavertonUV.Data.BeavertonUVContext _context;

        public DetailsModel(BeavertonUV.Data.BeavertonUVContext context)
        {
            _context = context;
        }

      public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Instructors == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors.FirstOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }
            else 
            {
                Instructor = instructor;
            }
            return Page();
        }
    }
}
