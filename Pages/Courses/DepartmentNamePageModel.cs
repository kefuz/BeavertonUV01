using BeavertonUV.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

/* The scaffolded code for the Course Create and Edit pages 
 * has a Department drop-down list that shows DepartmentID, 
 * an int. The drop-down should show the Department name, 
 * so both of these pages need a list of department names. 
 * 
 * To provide that list, use a base class for the Create and 
 * Edit pages.
 */

namespace BeavertonUV.Pages.Courses
{
    // Add Select List to PageModel
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }

        public void PopulateDepartmentsDropDownList(
            BeavertonUVContext _context,
            object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name // Sort by name.
                                   select d;

            DepartmentNameSL = new SelectList(
                departmentsQuery.AsNoTracking(),
                "DepartmentID", "Name", 
                selectedDepartment);
        }
    }
}