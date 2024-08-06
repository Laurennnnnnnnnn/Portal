using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class PeriodicalData
    {
        public int PeriodicalDataID { get; set; }
        public int PeriodicalOutputID { get; set; }
        public int StudentID { get; set; }
        public int Score { get; set; }
    }
}
