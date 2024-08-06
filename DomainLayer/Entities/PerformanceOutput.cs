using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class PerformanceOutput
    {
        public int PerformanceOutputID { get; set; }
        public string PerformanceOutputName { get; set; } = string.Empty;
        public string DateCreated { get; set; } = string.Empty;
        public int ClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int QuarterID { get; set; }
        public string QuarterName { get; set; } = string.Empty;
        public int MaxScore { get; set; }

        public float WeightedScore { get; set; }
        public PerformanceData? PerformanceData { get; set; }
    }
}
