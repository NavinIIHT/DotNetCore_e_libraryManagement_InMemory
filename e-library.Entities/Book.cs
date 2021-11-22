using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace e_library.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Published_Year { get; set; }
        public string Edition { get; set; }
        public Streams? Streams { get; set; }
        public bool Issued { get; set; }
    }
}
