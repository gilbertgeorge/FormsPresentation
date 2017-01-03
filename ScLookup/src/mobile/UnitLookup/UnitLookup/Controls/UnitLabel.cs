using UnitLookup.Services;
using Xamarin.Forms;

namespace UnitLookup.Controls
{
    public class UnitLabel : Label
    {
        public static BindableProperty UnitTypeProperty =
            BindableProperty.Create("UnitType", typeof(UnitType), typeof(UnitLabel), UnitType.AddOn);

        public UnitType UnitType
        {
            get { return (UnitType)GetValue(UnitTypeProperty); }
            set { SetValue(UnitTypeProperty, value); }
        }
    }
}
