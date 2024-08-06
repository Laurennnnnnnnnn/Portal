using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class PeriodicalOutput
    {
        public int PeriodicalOutputID { get; set; }
        public string PeriodicalOutputName { get; set; } = string.Empty;
        public string DateCreated { get; set; } = string.Empty;
        public int ClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int QuarterID { get; set; }
        public string QuarterName { get; set; } = string.Empty;
        public int MaxScore { get; set; }
        public float WeightedScore { get; set; }
        public PeriodicalData? PeriodicalData { get; set; }
    }
}
