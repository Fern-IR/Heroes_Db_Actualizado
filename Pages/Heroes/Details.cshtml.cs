using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Practica_Web.Data;
using Practica_Web.Models;

namespace Practica_Web.Pages_Heroes
{
    public class DetailsModel : PageModel
    {
        private readonly Practica_Web.Data.HeroesContext _context;

        public DetailsModel(Practica_Web.Data.HeroesContext context)
        {
            _context = context;
        }

        public Heroes Heroes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroes = await _context.Heroes.FirstOrDefaultAsync(m => m.Id == id);

            if (heroes is not null)
            {
                Heroes = heroes;

                return Page();
            }

            return NotFound();
        }
    }
}
