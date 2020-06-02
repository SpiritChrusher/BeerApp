using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BeerApp.Backend
{
    class Search
    {

      
        public static string BeerSearch(List<BeerPOJO> allbeer ,string beername)
        {
            int point = 0;
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
            if (point == 0)
            {
                return "Nincs ilyen sör";
            }
            else
            {
                return found;
            }


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
