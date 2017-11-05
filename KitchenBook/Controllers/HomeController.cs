using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenBook.Models;

namespace KitchenBook.Controllers
{
    public class HomeController : Controller
    {

        static KitchenBookContext db;
        static List<Ingridient> toSearch;
        static List<Ingridient> items;
        static HomeController homeController;
        static List<Dish> FoundDishes;
        public HomeController()
        {
            if (homeController == null)
            {
                FoundDishes = new List<Dish>();
                db = new KitchenBookContext();
                toSearch = new List<Ingridient>();
                items = db.getIngridients();
                homeController = this;
            }

        }
        public ActionResult Index()
        {
            FoundDishes = db.getDishesWithIngridients(toSearch);
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult GetAutoComplete(string term)
        {
           
            var ListToSearch = new List<Ingridient>();
            string[] ingridientsToAdd = new string[1];
            if (term.Contains(","))
            {
                ingridientsToAdd = term.Split(',');
                for(int i = 0; i < ingridientsToAdd.Length; i++ )
                {
                    var searching = ingridientsToAdd[i] = ingridientsToAdd[i].Replace(",", "").Trim();                   
                    var ing = items.Where(n => n.Equals(searching)).FirstOrDefault();

                    if(ing != null)
                    {
                        if (!toSearch.Contains(ing))
                            ListToSearch.Add(ing);
                    }
                    
                }
            }
            toSearch = ListToSearch;
            if (ingridientsToAdd.Length > 1) {
                term = ingridientsToAdd.Last();
            }
             var filteredItems = items.Where(n => n.Name.StartsWith(term)).Select(n => new {Name = n.Name}).ToList();
            
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public void Search()
        {
            FoundDishes = db.getDishesWithIngridients(toSearch);
            
        }

    }
}