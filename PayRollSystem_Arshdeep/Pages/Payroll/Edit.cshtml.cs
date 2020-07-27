using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayRollSystem_Arshdeep.BussinessLayer;
using PayRollSystem_Arshdeep.Data;

namespace PayRollSystem_Arshdeep.Pages.Payroll
{
    public class EditModel : PageModel
    {
        private readonly PayRollSystem_Arshdeep.Data.ApplicationDbContext _context;

        public EditModel(PayRollSystem_Arshdeep.Data.ApplicationDbContext context)
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
           ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Payroll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayrollExists(Payroll.ID))
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

        private bool PayrollExists(int id)
        {
            return _context.Payrolls.Any(e => e.ID == id);
        }
    }
}
