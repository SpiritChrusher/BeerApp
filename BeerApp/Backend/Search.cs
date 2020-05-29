using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Backend
{
    class Search
    {

        public static string BeerSearch(List<Beers> allbeer ,string beername)
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
    }
}
