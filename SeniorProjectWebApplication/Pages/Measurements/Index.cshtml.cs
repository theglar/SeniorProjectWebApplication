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
    public class IndexModel : PageModel
    {
        private readonly SeniorProjectWebApplication.Data.SeniorProjectWebApplicationContext _context;

        public IndexModel(SeniorProjectWebApplication.Data.SeniorProjectWebApplicationContext context)
        {
            _context = context;
        }

        public IList<Measurement> Measurement { get;set; }

        public async Task OnGetAsync()
        {
            Measurement = await _context.Measurement.ToListAsync();
        }
    }
}
