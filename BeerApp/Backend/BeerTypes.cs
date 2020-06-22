using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerApp.Backend
{
    enum Types
    {
        Radler = 2,
        Lager = 4,
        Ale =4,
        Hoplager,
        Pils,
        Munchener_Hell = 6,
        Búzasör = 6,
        Weissbier = 6,
        Session_IPA,
        Witbier,
        Porter,
        Stout,
        American_Pale_Ale = 10,
        IPA = 10,
        Imperial_IPA = 14,
        Imperial_Stout = 10,
        Tripel = 14,
        Russian_Imperial_Stout,
        Quadrupel,

    }

    enum Tastes
    {
        
        kicsit_keserű,
        közepesen_keserű,
        nagyon_keserű,
        kellemes,
        könnyen_iható,
        gyümölcsös,
        tömény,
        komplex,


    }

    class BeerTypes
    {

        public static ushort Typepoints(List<string> types)
        {

            ushort point = 0;

            foreach (var item in types)
            {
                foreach (int item2 in Enum.GetValues(typeof(Types)))
                {
                   
                    if (item.ToLower() == ((Types)item2).ToString().Replace('_',' ').ToLower())
                    {
                        point += (ushort)item2;
                    }
                }
            }
            return point;
        }

        public static ushort Tastepoints(List<string> tastes)
        {

            ushort point = 0;
       

            foreach (var item in tastes)
            {
                foreach (int item2 in Enum.GetValues(typeof(Tastes)))
                {
                    if (item.ToLower() == ((Tastes)item2).ToString().Replace('_', ' ').ToLower())
                    {
                        point += (ushort)item2;
                    }
                }
            }
            return point;
        }

        public decimal Price_value( BeerPOJO currentbeer)
        {
            decimal value = 0;
            if (currentbeer.price != 9999 || currentbeer.price != 0)
            {
                value = ((Typepoints(currentbeer.type) * currentbeer.quality) / currentbeer.price) * 100;

            }
            else
            {
                value = 0;
            }
            return value;
        }

    }
}
