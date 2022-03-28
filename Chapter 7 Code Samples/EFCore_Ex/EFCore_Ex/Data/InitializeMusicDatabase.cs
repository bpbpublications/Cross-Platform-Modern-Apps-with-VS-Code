using EFCore_Ex.Models;
using System.Linq;

namespace EFCore_Ex.Data
{
    public class InitializeMusicDatabase
    {
        
        public static void Initialize(MusicContext context)
        {

            if (context.Genre.Any())
            {
                return;   
            }

            var genres = new Genre[]
            {
                new Genre{ID = 1, Description = "Metal"}
            };

            context.Genre.AddRange(genres);
            context.SaveChanges();

            var musicians = new Musician[]
            {
                new Musician{ID = 1, Description = "Metallica"}
            };

            context.Musician.AddRange(musicians);
            context.SaveChanges();

            var songs = new Song[]
            {
                new Song{ID = 1, Description = "Master of Puppets"}
            };

            context.Song.AddRange(songs);
            context.SaveChanges();
        }
    }
}