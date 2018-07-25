using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorProjectWebApplication.Data;

namespace SeniorProjectWebApplication.Pages.Measurements
{
    public class EditModel : PageModel
    {
        private readonly SeniorProjectWebApplication.Data.SeniorProjectWebApplicationContext _context;

        public EditModel(SeniorProjectWebApplication.Data.SeniorProjectWebApplicationContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Measurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(Measurement.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurement.Any(e => e.ID == id);
        }
    }
}
