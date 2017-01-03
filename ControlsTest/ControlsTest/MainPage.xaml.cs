using ControlsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ControlsTest
{
    public partial class MainPage : ContentPage
    {
        private IDictionary<FactionEnum, StarcraftFaction> _scFactions;

        public MainPage()
        {
            InitializeComponent();

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = new List<Person>
            {
                new Person { Name = "Steve Farrell", Age = 61 },
                new Person { Name = "Brenda Farrell", Age = 60 },
                new Person { Name = "Jason Farrell", Age = 33 },
                new Person { Name = "Sean Farrell", Age = 31 },
                new Person { Name = "Cory Farrell", Age = 28 },
            };

            _scFactions = new Dictionary<FactionEnum, StarcraftFaction>
            {
                { FactionEnum.Terran, new StarcraftFaction(FactionEnum.Terran) },
                { FactionEnum.Zerg, new StarcraftFaction(FactionEnum.Zerg) },
                { FactionEnum.Protoss, new StarcraftFaction(FactionEnum.Protoss) },
            };

            foreach (var f in _scFactions)
            {
                picker.Items.Add(f.Value.Name);
            }
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedIndex = picker.SelectedIndex;

            var selectedKey = _scFactions.Keys.ToArray()[selectedIndex];
            var faction = _scFactions[selectedKey];

            if (faction.Faction == FactionEnum.Terran)
            {
                await DisplayAlert("Awesome", "Terran is clearly the best, nothing else competes!! Glory to Polt and Byun!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Booo", "Terran is the only race!! All others must submit or die!!!", "Ok");
            }
        }
    }
}
