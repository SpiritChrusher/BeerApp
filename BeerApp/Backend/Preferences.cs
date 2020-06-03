using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace BeerApp.Backend
{
    class Preferences
    {
    /*    void AddToList(string text)
        {
            var savedList = new List<string>(Preferences.SavedList);

            savedList.Add(text);

            Preferences.SavedList = savedList;
        }


       public static List<string> SavedList
        {
            get
            {
                var savedList = Deserialize<List<string>>(Preferences(nameof(SavedList), null));
                return savedList ?? new List<string>();
            }
            set
            {
                var serializedList = Serialize(value);
                Preferences.Set(nameof(SavedList), serializedList);
            }
        }*/

        static T Deserialize<T>(string serializedObject) => JsonConvert.DeserializeObject<T>(serializedObject);

        static string Serialize<T>(T objectToSerialize) => JsonConvert.SerializeObject(objectToSerialize);

    }
}
