using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Magneto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Magnetometer.Start(SensorSpeed.UI);
            Magnetometer.ReadingChanged += (s, e) =>
            {
                x.Text = e.Reading.MagneticField.X.ToString();
                y.Text = e.Reading.MagneticField.Y.ToString();
                z.Text = e.Reading.MagneticField.Z.ToString();
                var absVal = Convert.ToInt32(Math.Round(e.Reading.MagneticField.Length()));
                abs.Text = absVal.ToString();
                this.BackgroundColor = Color.FromRgb(255 - (absVal <= 510 ? absVal / 2 : 255), 0 + (absVal <= 510 ? absVal / 2 : 255), 0);
                if(absVal >= 300)
                    Vibration.Vibrate(50);
            };
        }
    }
}
