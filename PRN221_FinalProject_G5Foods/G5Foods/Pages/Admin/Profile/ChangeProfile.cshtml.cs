using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace G5Foods.Pages.Admin.Profile
{
    public class ChangeProfileModel : PageModel
    {
        private readonly G5Foods.Models.G5FoodsContext _context;

        public ChangeProfileModel(G5Foods.Models.G5FoodsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public G5Foods.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _context.Admins.FirstOrDefaultAsync(m => m.AdminId == id);

            if (Admin == null)
            {
                return NotFound();
            }
            return Page();
        }

        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Admin.AdminId))
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

        private bool CustomerExists(int id)
        {
            return _context.Admins.Any(e => e.AdminId == id);
        }
    }
}

