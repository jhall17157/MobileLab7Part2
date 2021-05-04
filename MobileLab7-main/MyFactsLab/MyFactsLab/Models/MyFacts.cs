using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyFactsLab.Models
{
    public class MyFacts
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string Img { get; set; }
    }
}
