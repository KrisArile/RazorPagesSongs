#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSongs.Data;
using RazorPagesSongs.Models;

namespace RazorPagesSongs.Pages.Songs
{
#pragma warning disable 8618
#pragma warning disable 8601
#pragma warning disable 8602
#pragma warning disable 8604
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesSongs.Data.RazorPagesSongsContext _context;

        public DeleteModel(RazorPagesSongs.Data.RazorPagesSongsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Song.FirstOrDefaultAsync(m => m.ID == id);

            if (Song == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Song.FindAsync(id);

            if (Song != null)
            {
                _context.Song.Remove(Song);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
#pragma warning restore 8618
#pragma warning restore 8601
#pragma warning restore 8602
#pragma warning restore 8604
}
