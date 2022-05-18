using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ps_8.Data;
using ps_8.Models;

namespace ps_8.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ps_8.Data.UniversityContext _context;

        public DetailsModel(ps_8.Data.UniversityContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.FirstOrDefaultAsync(m => m.id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
