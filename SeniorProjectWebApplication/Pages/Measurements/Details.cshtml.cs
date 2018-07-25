using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeniorProjectWebApplication.Data;

namespace SeniorProjectWebApplication.Pages.Measurements
{
    public class DetailsModel : PageModel
    {
        private readonly SeniorProjectWebApplication.Data.SeniorProjectWebApplicationContext _context;

        public DetailsModel(SeniorProjectWebApplication.Data.SeniorProjectWebApplicationContext context)
        {
            _context = context;
        }

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
    }
}
