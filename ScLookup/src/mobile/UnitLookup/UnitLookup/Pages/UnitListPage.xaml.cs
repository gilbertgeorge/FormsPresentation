using System.Linq;
using UnitLookup.Core;
using UnitLookup.Services;
using UnitLookup.Services.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitLookup.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitListPage : ContentPage
    {
        public UnitListPage(UnitFaction unitDisplay)
        {
            InitializeComponent();
            Title = unitDisplay.ToString();
            DisplayUnits(unitDisplay);

            unitList.ItemSelected += UnitList_ItemSelected;
        }

        void DisplayUnits(UnitFaction unitDisplay)
        {
            var service = ServiceContainer.Current.UnitService;
            var units = service.GetLoadedUnits().Where(x => x.UnitFaction == unitDisplay).ToList();

            unitList.ItemsSource = units;
        }

        async void UnitList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var unit = e.SelectedItem as Unit;
            if (unit != null)
            {
                var page = new UnitDetailPage(unit.UnitId);
                await Navigation.PushAsync(page, true);
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}
