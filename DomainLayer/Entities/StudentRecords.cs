using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class StudentRecords
    {
        public required List<RecordStudents> Student { get; set; }
    }

    public class RecordStudents
    {
        public int StudentID { get; set; }
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Birthdate { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string LRN { get; set; } = string.Empty;
        public int CreatorID { get; set; }

        public required Dictionary<string, WrittenOutput> WrittenOutput { get; set; }
        public required Dictionary<string, PerformanceOutput> PerformanceOutput { get; set; }
        public required Dictionary<string, PeriodicalOutput> PeriodicalOutput { get; set; }

        public required Dictionary<string, Quarters> Quarters { get; set; }
    }
    public class Quarters
    {
        public int QuarterID { get; set; }
        public int Grade { get; set; }
        public  Dictionary<string, WrittenOutput> WrittenOutput { get; set; }
        public  Dictionary<string, PerformanceOutput> PerformanceOutput { get; set; }
        public  Dictionary<string, PeriodicalOutput> PeriodicalOutput { get; set; }
    }

    public class FinalGrade
    {
        public int Grade { get; set; }
        public string GradeRemarks { get; set; }
    }
}
