using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitLookup.Core;
using UnitLookup.Services;
using UnitLookup.Services.Models;
using UnitLookup.ViewModels;
using Xamarin.Forms;

namespace UnitLookup.Pages
{
    public partial class UnitDetailPage : ContentPage
    {
        private readonly Guid _unitId;

        public UnitDetailPage(Guid unitId)
        {
            InitializeComponent();

            _unitId = unitId;
            requiresList.ItemSelected += RequiresList_ItemSelected;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var service = ServiceContainer.Current.UnitService;

                loadingIndicator.IsVisible = true;
                var unitDetail = await service.GetUnitById(_unitId);

                Title = unitDetail.Name;
                BindingContext = new UnitDetailViewModel(unitDetail);
                loadingIndicator.IsVisible = false;
                factionImage.Source = GetImage(unitDetail.UnitFaction);
            }
            catch (Exception ex)
            {
                loadingIndicator.IsVisible = false;
                await DisplayAlert("Error", "Failed to load Unit Details", "Ok");
            }
        }

        private async void RequiresList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var unit = e.SelectedItem as Unit;
            if (unit != null)
            {
                var page = new UnitDetailPage(unit.UnitId);
                await Navigation.PushAsync(page, true);
            }
        }

        static string GetImage(UnitFaction faction)
        {
            switch (faction)
            {
                case UnitFaction.Terran:
                    return "terran.png";
                case UnitFaction.Protoss:
                    return "protoss.png";
                default:
                    return "zerg.png";
            }
        }
    }
}
