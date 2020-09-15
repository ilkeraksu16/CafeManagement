using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entity.Models
{
    public class OrderDetay
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public long SumPrice { get; set; }
        public DateTime Time { get; set; }
        public int Count { get; set; }
    }
}
