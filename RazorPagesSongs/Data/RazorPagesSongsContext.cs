#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesSongs.Models;

namespace RazorPagesSongs.Data
{
    public class RazorPagesSongsContext : DbContext
    {
        public RazorPagesSongsContext (DbContextOptions<RazorPagesSongsContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesSongs.Models.Song> Song { get; set; }
    }
}
