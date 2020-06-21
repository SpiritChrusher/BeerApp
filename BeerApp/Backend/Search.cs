using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BeerApp.Backend
{
    public static class Search
    {
        public static List<BeerPOJO> PriceSearch(List<BeerPOJO> allbeer, string beertext)
        {
            List<BeerPOJO> valuebeers = new List<BeerPOJO>();

            bool success = int.TryParse(beertext, out int beerprice);
            
            if (success)
            {
                /* foreach (var item in allbeer)
                 {
                     if (Math.Abs(beerprice - item.price) < beerprice*0.15)
                     {
                         valuebeers.Add(item);
                     }
                 }*/
              valuebeers = allbeer.Where(x => (x.price - beerprice < beerprice * 0.15)).OrderBy(x => x.name).ToList();
            }

            else { return valuebeers;}

            return valuebeers;
        }

        public static string BeerSearch(List<BeerPOJO> allbeer, string beername)
        {
            ushort point = 0;

            string found = "";

            foreach (var item in allbeer)
            {
                if (item.name.ToLower() == beername.ToLower())
                {
                    point++;
                    found = item.ToString();
                    break;
                }
            }
            if (point == 0)  { return "Nincs ilyen sör"; }
            else { return found; }
        }

        public static List<BeerPOJO> BeerListSearch(List<BeerPOJO> allbeer, string beername)
        {
            List<BeerPOJO> foundlist = new List<BeerPOJO>();

            foreach (var item in allbeer)
            {
                if (item.name.ToLower().Contains(beername.ToLower()))
                {
                    foundlist.Add(item);
                }
            }
            return foundlist;
        }
        
    }
}
