using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica_Web.Data;
using Practica_Web.Models;

namespace Practica_Web.Pages_Heroes
{
    public class CreateModel : PageModel
    {
        private readonly Practica_Web.Data.HeroesContext _context;

        public CreateModel(Practica_Web.Data.HeroesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Heroes Heroes { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Heroes.Add(Heroes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
