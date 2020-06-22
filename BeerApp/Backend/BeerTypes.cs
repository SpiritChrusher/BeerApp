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
        Double_IPA,
        Teás_Double_IPA,
        Amerikai_IPA,
        Dubbel,
        Tripel,
        Quadrupel,
        APA,
        BAK,
        Amerikai_Lager,
        Baltic_Porter,
        Barna_Belga,
        Barna_lager,
        Belga_Ale,
        Witbeer,
        Búzasör,
        Félbarna_Lager,
        Gluténmentes_IPA,
        Hidegkomlós_Lager,
        Imperial_Sour_Ale,
        Imperial_Red_Ale,
        Imperial_Lager,
        Mézsör,
        Marzen,
        Lambic = 10,
        Meggy_Ale,
        Mentás_Imperial_Sout,
        Munchener_Lager,
        New_England_IPA,
        Szilvás_Lager,
        West_Coast_IPA,
        White_IPA,
        Whiskey_Ale,
        Tripel = 14,
        Russian_Imperial_Stout,
        Quadrupel,

    }

    enum Tastes
    {      
        kicsit_keserű,
        közepesen_keserű,
        nagyon_keserű,
        könnyen_iható,
        kellemes,
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
