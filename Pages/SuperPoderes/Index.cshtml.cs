using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Practica_Web.Data;
using Practica_Web.Models;

namespace Practica_Web.Pages_SuperPoderes
{
    public class IndexModel : PageModel
    {
        private readonly Practica_Web.Data.HeroesContext _context;

        public IndexModel(Practica_Web.Data.HeroesContext context)
        {
            _context = context;
        }

        public IList<SuperPoderes> SuperPoderes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SuperPoderes = await _context.SuperPoderes
                .Include(s => s.Heroe).ToListAsync();
        }
    }
}
