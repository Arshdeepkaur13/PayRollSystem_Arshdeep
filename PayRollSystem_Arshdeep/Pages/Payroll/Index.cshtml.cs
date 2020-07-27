using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PayRollSystem_Arshdeep.BussinessLayer;
using PayRollSystem_Arshdeep.Data;

namespace PayRollSystem_Arshdeep.Pages.Payroll
{
    public class IndexModel : PageModel
    {
        private readonly PayRollSystem_Arshdeep.Data.ApplicationDbContext _context;

        public IndexModel(PayRollSystem_Arshdeep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BussinessLayer.Payroll> Payroll { get;set; }

        public async Task OnGetAsync()
        {
            Payroll = await _context.Payrolls
                .Include(p => p.Employee).ToListAsync();
        }
    }
}
