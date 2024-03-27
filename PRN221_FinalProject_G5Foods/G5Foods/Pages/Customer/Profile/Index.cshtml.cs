using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace G5Foods.Pages.Customer.Profile
{
    public class IndexModel : PageModel
    {
        private readonly G5Foods.Models.G5FoodsContext _context;

        public IndexModel(G5Foods.Models.G5FoodsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public G5Foods.Models.Customer Customer { get; set; } = default!;
        public bool UpdateSuccess { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            //id = 1;
            //if (id == null || _context.Customers == null)
            //{
            //    return NotFound();
            //}

            //var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //Customer = customer;
            //return Page();
            id = 1;
            if (id == null)
            {
                return NotFound();
            }
            //Mem=await _context.Members.FindAsync(memberId);

            Customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);

            //Mem = await _context.Members.SingleOrDefaultAsync(m => m.MemberId == memberId);

            if (Customer == null)
            {
                return NotFound($"Not found customer with ID '{id}'.");
            }

            return Page();
        }


        //public async Task<IActionResult> OnPostAsync()
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return Page();
        //    //}

        //    //_context.Attach(Customer)=;

        //    //try
        //    //{

        //    //    await _context.SaveChangesAsync();

        //    //}
        //    //catch (DbUpdateConcurrencyException)
        //    //{
        //    //    if (!CustomerExists(Customer.CustomerId))
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //    else
        //    //    {
        //    //        throw;
        //    //    }
        //    //}
        //    //TempData["SuccessMessage"] = "Profile updated successfully!";

        //    //return RedirectToPage("./Index");
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Attach(Customer);
        //            _context.Entry(Customer).Property(c => c.CustomerName).IsModified = true;
        //            _context.Entry(Customer).Property(c => c.Email).IsModified = true;
        //            _context.Entry(Customer).Property(c => c.Password).IsModified = true;
        //            await _context.SaveChangesAsync();

        //        }
        //        catch (DBConcurrencyException)
        //        {
        //            if (!CustomerExists(Customer.CustomerId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }


        //    }
        //    TempData["SuccessMessage"] = "Profile updated successfully!";
        //    return Page();
        //}


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            // _context.Update(Customer);



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToPage("/Index");

        }



        private bool CustomerExists(int id)
        {
            //id = 1;
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
