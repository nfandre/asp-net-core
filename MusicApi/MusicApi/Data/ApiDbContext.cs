using System;
using Microsoft.EntityFrameworkCore;
using MusicApi.Models;

namespace MusicApi.Data
{
	public class ApiDbContext : DbContext
	{
		public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
		{
		}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to postgres with connection string from app settings
        //    options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        //}

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }


   //     protected override void OnModelCreating(ModelBuilder modelBuilder)
   //     {
			//modelBuilder.Entity<Song>().HasData(
			//	new Song
			//	{
			//		Id = 1,
			//		Title = "Yellow",
			//		Language = "English",
			//		Duration = "4:20"
			//	}
			//);
   //     }
    }
}

