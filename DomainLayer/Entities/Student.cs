using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? Gender { get; set; }
        public string? Birthdate { get; set; }
        public string? Remarks { get; set; }
        public string? LRN { get; set; }
        public int CreatorID { get; set; }
    }
}
