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

            string[] enterbeers = entrybeers.Split(',');

            foreach (var name in enterbeers)
            {
                string newname;
                if (name[0] == ' ')
                {
                    newname = name.Remove(0, 1);
                }
                else { newname = name; }

                foreach (var beer in beers)
                {                   

                    if (newname.ToLower() == beer.name.ToLower())
                    {
                        beer.Value = (BeerTypes.Typepoints(beer.type) + BeerTypes.Tastepoints(beer.taste)) * (beer.quality);
                        thebeers.Add(beer);
                        break;
                    }
                }
            }

            // List<BeerPOJO> recommended = thebeers.OrderBy(x => x.Value).ThenBy(y => y.name).ToList();

            return thebeers.OrderBy(x => x.Value).ThenBy(y => y.name).ToList();
        }
    }
}
