using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BeerApp
{
    public class BeerPOJO : INotifyPropertyChanged
    {
        public ushort Id { get; set; }

        public string name { get; set; }

        public decimal alcohol { get; set; }

        public List<string> taste { get; set; }

        public string origin { get; set; }

        public List<string> type { get; set; }

        public string manufacturer;

        public string consumption;

        public ushort price;

        public decimal quality;

        public List<string> acquisition;

        public decimal packformat;

        private bool _IsVisible { get; set; }

        public bool IsVisible
        {
            get
            {
                return _IsVisible;
            }
            set
            {
                if (_IsVisible != value)
                {
                    _IsVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }



        public BeerPOJO() { }

        public BeerPOJO(string aname, decimal aalcohol, List<string> ataste, string aorigin, List<string> atype,
            string amanufacturer, string aconsumption, ushort aprice, decimal aquality, List<string> aacquistion, decimal apackformat)
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

        public decimal Value { get; set; }

        public string DisplayAll => $"alkoholfok: {alcohol}%\nízvilág: {string.Join(", ", taste)}" +
                  $"\nszármazás: {origin} \ntípus: {type[type.Count - 1]} \ngyártó: {manufacturer}\n " +
                  $"fogyasztás:  {consumption}\n ár: {price} Forint\nminőség: {quality} pont" +
                  $"\nbeszerzési hely(ek): {string.Join(", ", acquisition)}\nkiszerelés: {packformat} liter";


    public override string ToString()
          {
              return $"name: {name}\nalkoholfok: {alcohol}%\ntaste: {string.Join(", ", taste)} " +
                  $"\nszármazás: {origin} \ntípus: {type[type.Count - 1]} \ngyártó: {manufacturer}\n " +
                  $"fogyasztás:  {consumption}\n ár: {price} Forint\nminőség: {quality} pont" +
                  $"\nbeszerzési hely(ek): {string.Join(", ", acquisition)}\nkiszerelés: {packformat} liter";
          }

        public string DisplayImportant => $"{alcohol}\n{Displayquality}";
       
     }

}
