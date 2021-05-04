using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFactsLab.Models;
using Xamarin.Forms;

namespace MyFactsLab
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetFactsAsync();
        }
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            MyFacts fact = (MyFacts)e.SelectedItem;
            DisplayAlert("The Fact", fact.TheFact, "Ok");
        }
    }
}
