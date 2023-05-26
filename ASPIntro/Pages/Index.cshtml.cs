using ASPIntro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPIntro.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly ASPIntro.Data.ASPIntroContext _context;

        public IndexModel(ASPIntro.Data.ASPIntroContext context)
        {
            _context = context;
        }

        public IList<Filme> Filme { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genero { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? GeneroFilme { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Filme != null)
            {
                Filme = await _context.Filme.ToListAsync();
            }
            IQueryable<string> generoQuery = from m in _context.Filme
                                             orderby m.Genre
                                             select m.Genre;
            var filmes = from m in _context.Filme select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                filmes = filmes.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(GeneroFilme))
            {
                filmes = filmes.Where(x => x.Genre == GeneroFilme);
            }
            Genero = new SelectList(await generoQuery.Distinct().ToListAsync());
            
            Filme = await filmes.Take(10).ToListAsync();
            //Filme = await filmes.Take(10).ToListAsync();


        }
    }
}
