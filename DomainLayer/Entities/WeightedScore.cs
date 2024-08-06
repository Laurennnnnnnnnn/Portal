using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class WeightedScore
    {
        public int WeightedScoreID { get; set; }
        public int SchoolYearID { get; set; }
        public int QuarterID { get; set; }
        public int ClassID { get; set; }
        public float Score { get; set; }
        public int OutputID { get; set; }
        public string OutputName { get; set; } = string.Empty;
        public string SchoolYearName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
    }
}
