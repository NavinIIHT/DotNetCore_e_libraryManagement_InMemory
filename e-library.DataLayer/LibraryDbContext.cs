using e_library.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace e_library.DataLayer
{
    public class LibraryDbContext :DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions)
            : base(dbContextOptions)
            {
                //Database.Migrate();
            }
        ///<summary>
        /// Creating DbSet for Table
        /// </summary>
        public DbSet<Student> students { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Book_Issue> book_Issues { get; set; }
    }
}
