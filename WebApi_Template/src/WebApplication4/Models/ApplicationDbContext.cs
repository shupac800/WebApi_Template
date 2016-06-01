using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;




namespace WebApi_Template.Models
{
    public class ApplicationDbContext : DbContext
    {
 
        public DbSet<Album>  Albums  { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.Entity<Album>()
                .ToTable("Album")
                .HasKey(k => k.AlbumId);

            builder.Entity<Artist>()
                .ToTable("Artist")
                .HasKey(k => k.ArtistId);
        }
       
    }
}
