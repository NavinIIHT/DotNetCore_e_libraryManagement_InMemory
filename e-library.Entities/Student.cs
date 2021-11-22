using System;
using System.ComponentModel.DataAnnotations;

namespace e_library.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Streams? streams { get; set; }
        public long Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
    }
}
