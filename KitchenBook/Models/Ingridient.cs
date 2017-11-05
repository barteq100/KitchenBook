using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenBook.Models
{
    public class Ingridient: IEquatable<Ingridient>
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public bool Equals(Ingridient other)
        {
            if (Id == other.Id) return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            var ing = obj as String;
            return this.Equals(ing);
        }

        public bool Equals(String other)
        {
            if (Name == other) return true;
            return false;
        }
    }
}