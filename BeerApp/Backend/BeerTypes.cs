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
        IPA = 10,
        Session_IPA = 10,
        Imperial_IPA = 8,
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

        public decimal Price_value()
        {
            decimal value = 0;



            return value;
        }

    }
}
