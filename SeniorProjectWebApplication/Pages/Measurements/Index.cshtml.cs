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
    public class IndexModel : PageModel
    {
        private readonly SeniorProjectWebApplication.Data.SeniorProjectWebApplicationContext _context;

        public IndexModel(SeniorProjectWebApplication.Data.SeniorProjectWebApplicationContext context)
        {
            _context = context;
        }

        public IList<Measurement> Measurement { get;set; }
        public SelectList Users { get; set; }
        public string UserName { get; set; }

        public async Task OnGetAsync(string searchString, string UserName)
        {
            IQueryable<string> userQuery = from m in _context.Measurement
                                            orderby m.UserName
                                            select m.UserName;


            var measurements = from m in _context.Measurement
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                measurements = measurements.Where(s => s.UserName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(UserName))
            {
                measurements = measurements.Where(x => x.UserName == UserName);
            }
            Users = new SelectList(await userQuery.Distinct().ToListAsync());
            Measurement = await measurements.ToListAsync();
        }
    }
}
