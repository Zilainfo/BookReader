using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookReader.Models;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace BookReader.Services
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
            optionsBuilder.UseSqlite(@"Filename=O:\Programs\DataBase\SqlLite\Mobile.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");

        }


    }
}
