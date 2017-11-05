using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KitchenBook.Models
{
    public class KitchenBookContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        public KitchenBookContext() : base("name=KitchenBookContext")
        {

        }

        public System.Data.Entity.DbSet<KitchenBook.Models.Ingridient> Ingridients { get; set; }

        public System.Data.Entity.DbSet<KitchenBook.Models.Dish> Dishes { get; set; }

        public List<Ingridient> getIngridients()
        {
            return Ingridients.Select(n => n).ToList<Ingridient>();
        }

        public List<Dish> getDishesWithIngridients(List<Ingridient> ingridients)
        {

            var foundDishes = Dishes.Where(dish => !ingridients.Except(dish.Ingridients.ToList()).Any()).ToList();
            return foundDishes;
        }
    }
}
