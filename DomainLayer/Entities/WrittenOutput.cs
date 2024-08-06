using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class WrittenOutput
    {
        public int WrittenOutputID { get; set; }
        public string WrittenOutputName { get; set; } = string.Empty;
        public string DateCreated { get; set; } = string.Empty;
        public int ClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int QuarterID { get; set; }
        public string QuarterName { get; set; } = string.Empty;
        public int MaxScore { get; set; }
        public float WeightedScore { get; set; }
        public WrittenData? WrittenData { get; set; }
    }
}
