using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerApp.Backend
{
    class Recommending
    {
        public static List<BeerPOJO> RecommendBeers(string entrybeers, List<BeerPOJO> beers)
        {
            List<BeerPOJO> thebeers = new List<BeerPOJO>();

            string[] allbeers = entrybeers.Split(',');

            foreach (var name in allbeers)
            {
                if (name[0] == ' ')
                {
                    name.Remove(0, 1);
                }
                foreach (var beer in beers)
                {
                    if (name == beer.name)
                    {
                        beer.Value = (BeerTypes.Typepoints(beer.taste) + BeerTypes.Tastepoints(beer.taste)) * (beer.quality);
                        thebeers.Add(beer);
                        break;
                    }
                }
                //még cikluson belül minden sörnek összértéket számítani valami BeerType-os metódussal és listához adni
                //aztán pedig linq-val érték szerint növekvő sorrendbe kell rakni és azt visszaadni.
            }

            // List<BeerPOJO> recommended = thebeers.OrderBy(x => x.Value).ThenBy(y => y.name).ToList();

            return thebeers.OrderBy(x => x.Value).ThenBy(y => y.name).ToList();
        }
    }
}
