using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class AttendanceRecord
    {
        public required List<StudentAttendance> Attendance { get; set; }
    }
    public class StudentAttendance
    {
        public int StudentID { get; set; }
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Gender { get; set; }
        public string Birthdate { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string LRN { get; set; } = string.Empty;
        public int CreatorID { get; set; }
        public required Dictionary<string, Attendance> AttendanceOutput { get; set; }
    }

    
}
