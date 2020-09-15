using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entity.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
