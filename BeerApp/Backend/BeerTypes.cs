﻿using System;
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
            decimal value;
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

        public static string[] Alltaste = { "Alap búzasör",
"Alap cseh típusú sör",
"Alap német sör",
"Amilyennek egy lagernek lennie kell",
"Az alap Dreher sör",
"Barna sörös íz",
"citromos",
"citrusos",
"cuvee íz",
"Definitív búzasör íz",
"Definitív cseh pils íz",
"édes",
"egyszerű",
"Élmény",
"enyhe",
"enyhe baransör íz",
"Enyhén barnasör íz",
"enyhén keserű",
"érdekes íz",
"erős",
"erős illatú",
"erős karamelles barna sör",
"erős kávés közép és utóíz",
"erős keserű világos sör",
"Fiatal komlós íz",
"fűszeres",
"Gyenge lager",
"gyümölcsös",
"Karakteres",
"karamelles",
"kávés",
"Kcisit búzasöros",
"kellemes",
"kellemes barna sör",
"kellemes illatú",
"kellemes pils íz",
"kellemes termeszetes íz",
"kellemesen kávés",
"kellemesen keserű",
"kellemesen meggyes",
"Kellemetlen",
"keserű",
"Kicsit",
"kicsit édes",
"kicsit fanyar",
"kicsit keserű",
"kicsit savanyú",
"Kicsit vízes",
"Kiegyensúlyozott ízvilágú",
"Kisse édes",
"komlós",
"komplex",
"Komplex",
"könnyed",
"könnyen iható",
"közepesen keserű",
"közepesen vízes",
"kukoricás",
"lágy",
"legjobb sör",
"Meggyes",
"Mint a kobanyai",
"Nagyon édes",
"Nagyon enyhe",
"nagyon karamelles",
"Nagyon kellemes",
"nagyon komplex",
"Nagyon meggyes",
"nem keserű",
"nem rossz",
"nem túl erős íz",
"nyers komló íz",
"olaszrízling",
"kicsit keserű utóíz",
"pörkölt íz",
"szénsavas",
"Tipikus cseh sör",
"Tipikus lager",
"Tipikus német sör",
"tömény íz",
"vanílias",
"a Sopronihoz hasonlo",
"áfonyás",
"akes utóízen",
"alcohol alig érezhető",
"alig erezhetoen búzasör jellegu sör",
"alkoholos",
"amerikai komlós",
"angol ale íz",
"barna sörösös íz",
"belga Búza",
"belga élesztős",
"boros",
"búzasör",
"citromle utóíz",
"citromos",
"citrusos",
"cukros",
"csak enyhén",
"cseh sör ",
"csehes íz",
"csípős-kakaós",
"csokis",
"de enyhén vízes",
"de jellegtelen",
"de kettotol jol erezheted magad",
"édes",
"édes íz",
"édes utóíz",
"egyedibb ízo",
"egyenletesen enyhén keserű",
"eleg egyedi íz",
"eleg nehez",
"eleg szénsavas",
"élesztős",
"élesztős íz",
"élesztős utóíz",
"enyhe",
"enyhe búzasör íz",
"enyhe íz",
"enyhe könnyed sör",
"enyhe lager",
"enyhe pörkölt keserűség",
"enyhén kesernyés",
"enyhén keserű",
"enyhén keserű sör",
"enyhén keserű utóíz",
"enyhén komlós",
"enyhén pörkölt ízű",
"enyhén stoutos",
"érdekes íz",
"erezhetoen szuretlen",
"erős íz",
"erős karamelles íz",
"erős szecsuáni bors íz",
"étcsokis",
"finom",
"frissito",
"frissíto",
"frissítő",
"fura utóíz",
"füstos",
"füstos ízű",
"fűszeres",
"fűszeres búzasör",
"gyümölcsös",
"gyümölcsös ",
"hányás utóíz",
"hidegkomlós íz",
"jegeskávés",
"jellegtelen",
"jellegtelen íz",
"jo angol ale",
"jo lager",
"jól csúszik",
"kakaos",
"karakteres",
"karamelles",
"karamelles íz",
"karamelles íz ",
"kávés",
"kávés ízű finom sör",
"kekszes",
"kekszes íz",
"kellemes",
"kellemes ",
"kellemes búzasör",
"kellemes íz",
"kellemes ízű",
"kellemes nem túl keserű",
"kellemes német lager",
"kellemes nyari sör",
"kellemesen gyümölcsös nyari sör",
"kellemetlen",
"kellemetlen utóíz",
"kellemetlül keserű utóíz",
"kellemtlen utóíz",
"kenyeres",
"kenyeres elesztos",
"kerti munkahoz tokeletes",
"keserédes",
"keserű",
"keserű utóíz",
"kevés íz",
"kicsit  barna búzasör íz",
"kicsit bananos utóíz",
"kicsit barnasor íz",
"kicsit belga",
"kicsit búzás",
"kicsit búzasör íz",
"kicsit csokis",
"kicsit édes",
"kicsit félrement",
"kicsit füstos",
"kicsit füstös",
"kicsit gyümölcsös",
"kicsit IPA",
"kicsit karamellas",
"kicsit karamellás ",
"kicsit karamelles",
"kicsit keserű",
"kicsit keserű ",
"kicsit keserű utóíz",
"kicsit keserű vörös sör íz",
"kicsit komlos",
"kicsit lager",
"kicsit pörkölt",
"kicsit savanyú",
"kicsit Stoutos",
"kicsit szénsavas",
"kicsit teás",
"kicsit vízes",
"kicsit vízesebb utóíz",
"kicsit vörös sör íz",
"kicst alcoholos",
"kiegyensúlyozott",
"kisse vízes íz",
"komlós",
"komlós íz",
"komlós keserű utóíz",
"komlós utóíz",
"komplex",
"korrekt búzasör íz",
"korrekt íz",
"korrekt lager",
"könnyed",
"könnyed ",
"könnyen iható",
"közepesen édes",
"közepesen füstös",
"közepesen keserű",
"közepesen komlos",
"közepesen komlós íz",
"közepesen könnyen iható",
"közepesen rossz",
"közepesen száraz",
"közepesen szénsavas",
"kremes",
"kukoricamentesen",
"kukoricas íz",
"kukoricás íz",
"kukoricás utóíz",
"külonleges",
"lageresen keserű",
"lágy",
"lágy búzasör",
"laza",
"malátás",
"malnas szorp",
"mar iható",
"meggyes",
"mézes",
"moderately caramel",
"nagyon enyhe",
"nagyon erős",
"nagyon finom",
"nagyon gyümölcsös",
"nagyon gyümölcsös ",
"nagyon karamelles",
"nagyon kávés",
"nagyon kávés íz",
"nagyon keserű",
"nagyon komplex",
"nagyon könnyen iható",
"nagyon mangós íz",
"nagyon mentás",
"nagyon rossz",
"nagyon savanyú utóíz",
"nagyon vizes",
"ne idd",
"nem erős",
"nem erős íz",
"nem félbarna",
"nem gyümölcsös",
"nem igazan tequilas",
"nem jo",
"nem karakteres íz",
"nem keserű",
"nem keserű ",
"nem rumos",
"nem szénsavas",
"nem tul erős",
"nem túl erős",
"nem túl erős íz",
"nem túl keserű",
"nem túl tolakodoan búzasör",
"pezsgős",
"pezsgős íz",
"pörkölt íz",
"pörkölt középíz",
"pörkölt utóíz",
"rossz",
"Saazer komlo",
"savanyú",
"selymes",
"semleges íz",
"spicy",
"száraz",
"szarazabb cseh lager",
"szénsavas",
"szirupos",
"teás",
"testes",
"tömény",
"tömény imperial stout",
"tömény íz ",
"vaníliás",
"vaníliás utóíz",
"vegyes íz"};
    } 
}
