using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFactsLab.Data;
using MyFactsLab.Models;
using Xamarin.Forms;

namespace MyFactsLab
{
    public partial class App : Application
    {
        static MyFactsDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static MyFactsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MyFactsDatabase();
                    prefillDatabase();

                }
                return database;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        static void prefillDatabase()
        {
            database.ClearAllAsync();
            
            List<MyFacts> all = new List<MyFacts>();
            all.Add(new MyFacts() { TheFact = "Scorpion's Iconic line was originally voiced by the creater", ShortFact = "Iconic Line", Img = "scorpion.jfif" });
            all.Add(new MyFacts() { TheFact = "Noob Saibot was a joke character turned menacing bad guy", ShortFact = "Tobias Boon", Img = "noobsaibot.jpg" });
            all.Add(new MyFacts() { TheFact = "It took 10 games to explain Johnny Cage's Green aura", ShortFact = "Green Power", Img = "johnnycage.jpg" });
            all.Add(new MyFacts() { TheFact = "Shang Tsung's duplicate mechanic was due to low memory", ShortFact = "No memory left", Img = "shangtsung.jpg" });
            all.Add(new MyFacts() { TheFact = "An error in the arcade machine hardware and fan theories created Ermac", ShortFact = "Error Macintosh", Img = "ermac.jpg" });

            database.InsertList(all);

        }
    }
}
