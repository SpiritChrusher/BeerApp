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
        Ale = 4,
        Hidegkomlós_Lager,
        Hoplager,
        Pils = 6,
        Munchener_Hell = 6,
        BAK,
        Búzasör = 6,
        Weissbier = 6,
        Session_IPA,
        New_England_IPA,
        Porter,
        Stout,
        American_Pale_Ale = 10,
        Witbier = 10,
        IPA = 10,
        Imperial_IPA = 14,
        West_Coast_IPA,
        Imperial_Stout = 10,
        Double_IPA,
        Teás_Double_IPA,
        Amerikai_IPA,
        Belga_Ale = 8,
        Lambic = 8,
        Dubbel = 12,
        Tripel,
        Russian_Imperial_Stout,
        Quadrupel
        /* Amerikai_Lager,
         Baltic_Porter,
         Barna_Belga,
         Barna_lager,

         Félbarna_Lager,
         Gluténmentes_IPA,
         Imperial_Sour_Ale,
         Imperial_Red_Ale,
         Imperial_Lager,
         Mézsör,
         Marzen,
         Meggy_Ale,
         Mentás_Imperial_Sout,
         Munchener_Lager,
         Szilvás_Lager,
         White_IPA,
         Whiskey_Ale,
         */
    }

    public enum Tastes
    {      
        kicsit_keserű = 5,
        közepesen_keserű,
        nagyon_keserű,
        könnyen_iható = 5,
        kellemes = 7,
        gyümölcsös = 6,
        nagyon_gyümölcsös,
        tömény = 10,
        komplex,
    }
    
    class BeerTypes
    {
        private string[] IPAgood = {"keserű", "közepesen keserű", "nagyon keserű", "könnyen iható", "kellemes" };


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
