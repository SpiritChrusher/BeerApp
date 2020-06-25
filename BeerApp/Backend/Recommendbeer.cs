using BeerApp;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Mobeer.Backend
{
    class Recommendbeer
    {
        public static List<string> BeertoRecommend(List<string> beertastes, List<BeerPOJO> beers)
        {
            List<string> recommend = new List<string>();

            foreach (var beer in beers)
            {
                ushort same = 0;
                foreach (var currenttaste in beertastes)
                {
                    for(int i = beer.taste.Count -1; i >= 0; i--)
                    {
                        if (currenttaste == beer.taste[i])
                        {
                            same++;
                            beer.taste.RemoveAt(i);
                        }
                    }
                }
                if (same >= 2 && same >= beertastes.Count - 1)
                {
                    recommend.Add(beer.name);
                }
            }       
            return recommend;
        }
    }
}
