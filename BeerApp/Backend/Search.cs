using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public static List<BeerPOJO> RecommendBeers(string entrybeers)
        {
            List<BeerPOJO> recommended = new List<BeerPOJO>();

            string[] allbeers = entrybeers.Split(',');
            foreach (var item in allbeers)
            {
                if (item[0] == ' ')
                {
                    item.Remove(0, 1);
                }
                //még cikluson belül minden sörnek összértéket számítani valami BeerType-os metódussal és listához adni
                //aztán pedig linq-val érték szerint növekvő sorrendbe kell rakni és azt visszaadni.
            }




            return recommended;
        }
    }
}
