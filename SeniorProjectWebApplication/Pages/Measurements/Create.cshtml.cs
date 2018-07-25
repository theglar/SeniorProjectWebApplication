using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeniorProjectWebApplication.Models;

namespace SeniorProjectWebApplication.Pages.Measurements
{
    public class CreateModel : PageModel
    {
        private readonly SeniorProjectWebApplication.Models.SeniorProjectWebApplicationContext _context;

        public CreateModel(SeniorProjectWebApplication.Models.SeniorProjectWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Measurement Measurement { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Measurement.Add(Measurement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}