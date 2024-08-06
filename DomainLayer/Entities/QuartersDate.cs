using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class QuartersDate
    {
        public int QuartersDateID { get; set; }
        public string DateFrom { get; set; } = string.Empty;
        public DateTime From { get; set; } 
        public string DateTo { get; set; } = string.Empty;
        public DateTime To { get; set; } 
        public int SchoolYearID { get; set; }
        public int QuarterID { get; set; }
        public string QuarterName { get; set; } = string.Empty;
        public string SchoolYearName { get; set; } = string.Empty;
    }
}
