using Microsoft.EntityFrameworkCore;
using RazorPagesSongs.Data;

namespace RazorPagesSongs.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesSongsContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<RazorPagesSongsContext>>()))
            {
                if (context == null || context.Song == null)
                {
                    throw new ArgumentNullException("Null RazorPagesSongsContext");
                }

                if (context.Song.Any())
                {
                    return;
                }
                context.Song.AddRange(
                    new Song
                    {
                        Title = "Iugoy Mo Badong",
                        ReleaseDate = DateTime.Parse("2022-3-22"),
                        Genre = "Folk Song",
                        Price = 7.99M
                    },
                    new Song
                    {
                        Title = "Jumbo Hotdog",
                        ReleaseDate = DateTime.Parse("2020-3-22"),
                        Genre = "Folk Song",
                        Price = 8.99M
                    },
                    new Song
                    {
                        Title = "Himig Ng Bungi",
                        ReleaseDate = DateTime.Parse("2000-3-22"),
                        Genre = "Pop",
                        Price = 9.99M
                    }
                    );
                context.SaveChanges();
        }

        }

    }
}
