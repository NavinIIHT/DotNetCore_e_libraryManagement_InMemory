using e_library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_library.BusinessLayer.ViewModels
{
    public class StudentViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Streams? streams { get; set; }
        public long Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
    }
}
