using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookReaderYouTube.Core.Models;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace BookReaderYouTube.Core
{
    public class BookReaderContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookReaderContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=.\Mobile.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");

        }


    }
}
