using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entity.Models
{
    public class Food
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string FoodName { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsActive { get; set; }
        public long Price { get; set; }
    }
}
