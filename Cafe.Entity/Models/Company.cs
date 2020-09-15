using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entity.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int TablesCount { get; set; }
    }
}
