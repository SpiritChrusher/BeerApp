using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public bool Isfavorite { get; set; }

        public bool IsVisible { get; set; }

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
            IsVisible = false;
          
           
        }
        public string Displayquality => $"Quality: {quality}";

        

        public string Displaytype => $"{type[type.Count - 1]}";


        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public string DisplayAll => $"alcohol: { alcohol}%\ntaste: { string.Join(", ", taste)}" +
                  $"\norigin: {origin} \ntype: {type[type.Count - 1]} \nmanufacturer: {manufacturer}\n " +
                  $"consumption:  {consumption}\n price: {price}\nquality: {quality} pont" +
                  $"\nacquisition: {string.Join(", ", acquisition)}\npack: {packformat}\tfavorite: {IsChecked}";


    public override string ToString()
          {
              return $"name: {name}\nalcohol: {alcohol}%\ntaste: {string.Join(", ", taste)} " +
                  $"\norigin: {origin} \ntype: {type[type.Count - 1]} \nmanufacturer: {manufacturer}\n " +
                  $"consumption:  {consumption}\n price: {price}\nquality: {quality} pont" +
                  $"\nacquisition: {string.Join(", ", acquisition)}\npack: {packformat}\tfavorite: {IsChecked}";
          }
       
     }

}
