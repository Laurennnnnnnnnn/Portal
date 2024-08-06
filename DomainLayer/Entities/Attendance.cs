using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set;}
        public int ClassID { get; set;}
        public int QuarterID { get; set;}
        public string AttendanceDate { get; set; } = string.Empty;
        public int StatusID { get; set;}
        public string StatusName{ get; set;} = string.Empty;

            
    }
}
