using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;


namespace BeerApp
{
    public class BeerPOJO
    {
        public string name { get; set; }

        public decimal alcohol { get; set; }

        public List<string> taste { get; set; }

        public string origin { get; set; }

        public List<string> type { get; set; }

        public string manufacturer;

        public string consumption;

        public int price;

        public decimal quality;

        public List<string> acquisition;

        public decimal packformat;

        public BeerPOJO() { }

        public BeerPOJO(string aname, decimal aalcohol, List<string> ataste, string aorigin, List<string> atype,
            string amanufacturer, string aconsumption, int aprice, decimal aquality, List<string> aacquistion, decimal apackformat)
        {
            name = aname;
            alcohol = aalcohol;
            taste = ataste;
            origin = aorigin;
            type = atype;
            manufacturer = amanufacturer;
            consumption = aconsumption;
            price = aprice;
            quality = aquality;
            acquisition = aacquistion;
            packformat = apackformat;
        }


        public override string ToString()
        {
            return $"name: {name}\n alcohol: {alcohol}\n taste: {string.Join(", ", taste)} " +
                $"\n origin: {origin} \n type: {type[type.Count - 1]} \n manufacturer: {manufacturer}\n " +
                $"consumption:  {consumption}\n price: {price}\n quality: {quality} " +
                $"\n acquisition: {string.Join(", ", acquisition)}\n  packformat: {packformat}";
        }
    }

}
