using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class PerformanceData
    {
        public int PerformanceDataID { get; set; }
        public int PerformanceOutputID { get; set; }
        public int StudentID { get; set; }
        public int Score { get; set; }
    }
}
