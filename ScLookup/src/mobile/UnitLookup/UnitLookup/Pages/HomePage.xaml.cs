
using UnitLookup.Core;
using UnitLookup.Services;
using Xamarin.Forms;

namespace UnitLookup.Pages
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Children.Count == 0)
            {
                var service = ServiceContainer.Current.UnitService;
                if (await service.LoadAllUnitsAsync())
                {
                    // Handle when your app starts
                    Children.Add(new UnitListPage(UnitFaction.Terran));
                    Children.Add(new UnitListPage(UnitFaction.Protoss));
                    Children.Add(new UnitListPage(UnitFaction.Zerg));
                }
                else
                {
                    await DisplayAlert("Error", "Failed to load Units", "Ok");
                }
            }
        }
    }
}
