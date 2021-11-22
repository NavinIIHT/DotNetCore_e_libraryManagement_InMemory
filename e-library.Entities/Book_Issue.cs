using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace e_library.Entities
{
    public class Book_Issue
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime Issue_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public DateTime ActualReturn_Date { get; set; }
        public double Fine { get; set; }
        public bool Returned { get; set; }
    }
}
