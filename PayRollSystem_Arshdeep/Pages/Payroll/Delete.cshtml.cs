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
    public class DeleteModel : PageModel
    {
        private readonly PayRollSystem_Arshdeep.Data.ApplicationDbContext _context;

        public DeleteModel(PayRollSystem_Arshdeep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BussinessLayer.Payroll Payroll { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payroll = await _context.Payrolls
                .Include(p => p.Employee).FirstOrDefaultAsync(m => m.ID == id);

            if (Payroll == null)
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

            Payroll = await _context.Payrolls.FindAsync(id);

            if (Payroll != null)
            {
                _context.Payrolls.Remove(Payroll);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
