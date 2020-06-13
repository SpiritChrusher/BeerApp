using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Backend
{
    enum Types
    {
        Radler = 2,
        Lager,
        Hoplager,
        Munchener,
        IPA = 10,
        Session_IPA = 10,
        Imperial_IPA = 8,
        Imperial_Stout = 10,
        Russian_Imperial_Stout,
    }

    enum Tastes
    {
        kellemes,
        kicsit_keserű,
        könnyen_iható,

    }

    class BeerTypes
    {
        public int Typepoints(BeerPOJO beer)
        {

            int point = 0;

            foreach (var item in beer.type)
            {
                foreach (var item2 in Enum.GetValues(typeof(Types)))
                {
                    if (item.ToLower() == item2.ToString().Replace('_',' ').ToLower())
                    {
                        point += (int)item2;
                    }
                }
            }
            return point;
        }

        public decimal Price_value( BeerPOJO currentbeer)
        {
            decimal value = 0;



            return value;
        }

    }
}
