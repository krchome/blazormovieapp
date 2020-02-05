using System;
using System.Collections.Generic;
using System.Text;
using BlazorMovieApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovieApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Movie>().HasData
                (
                  new Movie
                  {
                      Id = 10,
                      Title = "The Sound Of Music",
                      ReleaseDate = new DateTime(1965, 3, 2),
                      Genre = "Musical drama",
                      Director = "Robert Wise",
                      RunningTime = 175
                  },
                   new Movie
                   {
                       Id = 20,
                       Title = "Hatari",
                       ReleaseDate = new DateTime(1962, 6, 19),//DateTime.Parse("1962-6-19").Date,
                       Genre = "Adventure",
                       Director = "Howard Hawks",
                       RunningTime = 158
                   },

                     new Movie
                     {
                         Id = 30,
                         Title = "The Exorcist",
                         ReleaseDate = new DateTime(1973, 12, 26),//DateTime.Parse("1973-12-26").Date,
                         Genre = "Supernatural horror",
                         Director = "William Friedkin",
                         RunningTime = 133

                     },
                      new Movie
                      {
                          Id = 40,
                          Title = "Back to the Future ",
                          ReleaseDate = new DateTime(1985, 7, 3), //DateTime.Parse("1985-7-3").Date,
                          Director = "Robert Zemeckis",
                          Genre = "Science Fiction",
                          RunningTime = 116

                      }
                );

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
