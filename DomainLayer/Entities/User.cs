using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int UserTypeID { get; set; }
        public int CategoryID { get; set; }
        public bool Activate { get; set; }
        public string Designation { get; set; } = string.Empty;
        public string UserTypeName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
