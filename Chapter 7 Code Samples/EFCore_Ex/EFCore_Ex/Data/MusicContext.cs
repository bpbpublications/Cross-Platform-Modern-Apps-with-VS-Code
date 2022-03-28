using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCore_Ex.Models;

namespace EFCore_Ex.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext (DbContextOptions<MusicContext> options)
            : base(options)
        {
        }

        public DbSet<EFCore_Ex.Models.Genre> Genre { get; set; }
        public DbSet<EFCore_Ex.Models.Musician> Musician { get; set; }
        public DbSet<EFCore_Ex.Models.Song> Song { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Musician>().ToTable("Musician");
            modelBuilder.Entity<Song>().ToTable("Song");
        }
    }
}
