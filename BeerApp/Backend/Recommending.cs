using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerApp.Backend
{
    class Recommending
    {
        public static List<BeerPOJO> RecommendBeers(List<string> entrybeers, List<BeerPOJO> beers)
        {
            List<BeerPOJO> thebeers = new List<BeerPOJO>();

            foreach (var name in entrybeers)
            {
                string newname;
                if (name[0] == ' ')
                {
                    newname = name.Remove(0, 1);
                }
                else { newname = name; }

                #region ForRegion
                foreach (var beer in beers)
                {
                    if (newname.ToLower() == beer.name.ToLower())
                    {
                        beer.Value = (BeerTypes.Typepoints(beer.type) + BeerTypes.Tastepoints(beer.taste)) * (beer.quality);
                        thebeers.Add(beer);
                        break;
                    }
                } 
                #endregion
            }
            return thebeers.OrderBy(x => x.Value).ThenBy(y => y.name).ToList();
        }
    }
}
