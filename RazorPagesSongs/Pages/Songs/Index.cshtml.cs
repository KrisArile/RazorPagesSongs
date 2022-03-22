#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesSongs.Data;
using RazorPagesSongs.Models;


namespace RazorPagesSongs.Pages.Songs
{
#pragma warning disable 8618
#pragma warning disable 8604
    public class IndexModel : PageModel
    {
        private readonly RazorPagesSongs.Data.RazorPagesSongsContext _context;

        public IndexModel(RazorPagesSongs.Data.RazorPagesSongsContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SongGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Song
                                            orderby m.Genre
                                            select m.Genre;
            var songs = from m in _context.Song
                        select m;
            if (!string.IsNullOrEmpty (SearchString))
            {
                songs = songs.Where(s => s.Title.Contains (SearchString));
            }
            if (!string.IsNullOrEmpty(SongGenre))
            {
                Song = await songs.ToListAsync();
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Song = await songs.ToListAsync();
        }
    }
#pragma warning restore 8618
#pragma warning restore 8604
}
