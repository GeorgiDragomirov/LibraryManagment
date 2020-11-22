using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagment.Models;

namespace LibraryManagment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LibraryManagment.Models.Member> Member { get; set; }
        public DbSet<LibraryManagment.Models.BookCategory> BookCategory { get; set; }
        public DbSet<LibraryManagment.Models.Book> Book { get; set; }
        public DbSet<LibraryManagment.Models.Lending> Lending { get; set; }
    }
}
