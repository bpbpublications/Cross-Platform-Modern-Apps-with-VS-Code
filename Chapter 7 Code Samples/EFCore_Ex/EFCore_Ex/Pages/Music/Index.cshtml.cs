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
    public class IndexModel : PageModel
    {
        private readonly EFCore_Ex.Data.MusicContext _context;

        public IndexModel(EFCore_Ex.Data.MusicContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; }

        public async Task OnGetAsync()
        {
            Genre = await _context.Genre.ToListAsync();
        }
    }
}
