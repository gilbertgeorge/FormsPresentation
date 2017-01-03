using UnitLookup.Core;
using UnitLookup.Pages;
using Xamarin.Forms;

namespace UnitLookup
{
    public partial class UnitLookupApplication : Application
    {
        public UnitLookupApplication()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new HomePage());
        }

        protected override async void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
