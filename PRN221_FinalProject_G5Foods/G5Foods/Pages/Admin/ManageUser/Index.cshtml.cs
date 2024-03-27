using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using G5Foods.Models;

namespace G5Foods.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly G5FoodsContext _context;
        public List<G5Foods.Models.Customer> Customer;
        public IndexModel(G5FoodsContext context)
        {
            _context = context;
        }


        public async Task OnGetAsync()
        {

            Customer = await _context.Customers.ToListAsync();

        }

    }
}
