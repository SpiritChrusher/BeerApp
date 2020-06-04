using SQLite;
using System;

namespace BeerApp.Backend
{
    class BeerSQL
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        public bool IsFavorite { get; set; }

        public BeerSQL(){ }

        public BeerSQL(string name)
        {
            Name = name;
        }
    }
}
