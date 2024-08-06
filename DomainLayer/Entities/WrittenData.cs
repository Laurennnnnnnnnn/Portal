using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class WrittenData
    {
        public int WrittenDataID { get; set; }
        public int StudentID { get; set; }
        public int WrittenOutputID { get; set; }
        public int Score { get; set; }
    }
}
