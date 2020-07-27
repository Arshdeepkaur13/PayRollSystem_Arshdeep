using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayRollSystem_Arshdeep.BussinessLayer;
using PayRollSystem_Arshdeep.Data;

namespace PayRollSystem_Arshdeep.Pages.Position
{
    public class CreateModel : PageModel
    {
        private readonly PayRollSystem_Arshdeep.Data.ApplicationDbContext _context;

        public CreateModel(PayRollSystem_Arshdeep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BussinessLayer.Position Position { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Positions.Add(Position);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
