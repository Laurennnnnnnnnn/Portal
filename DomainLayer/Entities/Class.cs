using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int SubjectID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public int GradeID { get; set; }
        public string GradeName { get; set; } = string.Empty;
        public int SectionID { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public int SchoolYearID { get; set; }
        public string SchoolYearName { get; set; } = string.Empty;
        public string Teacher { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }
}
