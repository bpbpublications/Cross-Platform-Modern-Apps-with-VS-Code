using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCore_Ex.Data;
using EFCore_Ex.Models;

namespace EFCore_Ex.Pages.Music
{
    public class DetailsModel : PageModel
    {
        private readonly EFCore_Ex.Data.MusicContext _context;

        public DetailsModel(EFCore_Ex.Data.MusicContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

                Genre = await _context.Genre
                    .Include(s => s.Musicians)
                    .ThenInclude(e => e.Songs)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(g => g.ID == id);

            if (Genre == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
