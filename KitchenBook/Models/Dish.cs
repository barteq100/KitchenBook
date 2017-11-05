using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenBook.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public IList<Ingridient> Ingridients { get; set; }
        public IList<int> Qunatities { get; set; }
        public List<String> Images { get; set; }
        public String  Guide { get; set; }
        public Guid User { get; set; }
        public DishType dishType { get; set; }
        public int Rate { get; set; }

        public enum DishType
        {
            Polish,
            Asian,
            Indian,
            Other
        };
    }


}