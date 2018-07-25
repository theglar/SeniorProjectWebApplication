using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeniorProjectWebApplication.Models;

namespace SeniorProjectWebApplication.Pages.Measurements
{
    public class DeleteModel : PageModel
    {
        private readonly SeniorProjectWebApplication.Models.SeniorProjectWebApplicationContext _context;

        public DeleteModel(SeniorProjectWebApplication.Models.SeniorProjectWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Measurement Measurement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Measurement = await _context.Measurement.SingleOrDefaultAsync(m => m.ID == id);

            if (Measurement == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Measurement = await _context.Measurement.FindAsync(id);

            if (Measurement != null)
            {
                _context.Measurement.Remove(Measurement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
