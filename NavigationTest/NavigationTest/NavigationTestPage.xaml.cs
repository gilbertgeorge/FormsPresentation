using Xamarin.Forms;

namespace NavigationTest
{
    public partial class NavigationTestPage : ContentPage
    {
        public NavigationTestPage()
        {
            InitializeComponent();
            modalButton.Clicked += ModalButton_Clicked;
            pushButton.Clicked += PushButton_Clicked;
        }

        async void ModalButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Page2());
        }

        async void PushButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }
    }
}
