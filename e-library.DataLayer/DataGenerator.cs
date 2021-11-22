using e_library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e_library.DataLayer
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<LibraryDbContext>>()))
            {
                if (context.students.Any())
                {
                    return;   // Data was already seeded
                }
                context.students.AddRange(
                    new Student
                    {
                        Id = 1,
                        Name = "Kundan",
                        Email = "umakumarsingh@techademy.com",
                        streams = Streams.Science,
                        Phone = 9631438123,
                        DOB = new DateTime(1990,03,01),
                        Address = "Banglore"
                    });
                context.SaveChanges();
                if (context.books.Any())
                {
                    return;   // Data was already seeded
                }
                context.books.AddRange(
                    new Book
                    {
                        Id = 1,
                        BookName = "Physics - 1",
                        ISBN = "10091",
                        Author = "K C Sinha",
                        Publisher = "Sinha",
                        Published_Year = 1990,
                        Edition = "First",
                        Streams = Streams.Science,
                        Issued = true
                    },
                    new Book
                    {
                        Id = 2,
                        BookName = "C Language",
                        ISBN = "10023",
                        Author = "Yasbant C",
                        Publisher = "K C Y",
                        Published_Year = 2021,
                        Edition = "6 th",
                        Streams = Streams.Science,
                        Issued = false
                    });
                context.SaveChanges();
            }
        }
    }
}
