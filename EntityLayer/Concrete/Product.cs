using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
		public AppUser AppUser { get; set; }
		public int AppUserId { get; set; }
		public string CityName { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public bool StockStatus { get; set; }
        public string PhoneNumber { get; set; }
    }
}
