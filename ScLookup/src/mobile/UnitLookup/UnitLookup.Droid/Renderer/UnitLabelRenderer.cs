using UnitLookup.Droid.Renderer;
using Xamarin.Forms;
using UnitLookup.Controls;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(UnitLabel), typeof(UnitLabelRenderer))]
namespace UnitLookup.Droid.Renderer
{
    public class UnitLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                var unitLabel = Element as UnitLabel;
                if (unitLabel != null)
                {
                    switch (unitLabel.UnitType)
                    {
                        case Services.UnitType.AddOn:
                            unitLabel.TextColor = Color.Green;
                            break;
                        case Services.UnitType.Air:
                            unitLabel.TextColor = Color.Blue;
                            break;
                        case Services.UnitType.Building:
                            unitLabel.TextColor = Color.Purple;
                            break;
                        case Services.UnitType.Ground:
                            unitLabel.TextColor = Color.Maroon;
                            break;
                        case Services.UnitType.Upgrade:
                            unitLabel.TextColor = Color.Orange;
                            break;
                        default:
                            unitLabel.TextColor = Color.Black;
                            break;
                    }
                }
            }
        }
    }
}