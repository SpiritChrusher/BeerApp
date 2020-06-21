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
        Munchener_Hell,
        Weissbier,
        Búzasör,
        Witbier,
        Session_IPA,
        IPA = 10,
        Imperial_IPA = 14,
        Imperial_Stout = 10,
        Russian_Imperial_Stout,

    }

    enum Tastes
    {
        kellemes,
        kicsit_keserű,
        közepesen_keserű,
        nagyon_keserű,
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
                foreach (var item2 in Enum.GetValues(typeof(Types)))
                {
                    if (item.ToLower() == item2.ToString().Replace('_',' ').ToLower())
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
                foreach (var item2 in Enum.GetValues(typeof(Tastes)))
                {
                    if (item.ToLower() == item2.ToString().Replace('_', ' ').ToLower())
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
