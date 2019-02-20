using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPWheather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RootObject myWeather = await OpenWeatherMapProxycs.GetWeather(45.0, 45.3);
            ResultTextBlock.Text = myWeather.name + "-"
                                                  +((Int32) myWeather.main.temp).ToString()+ "-" + myWeather.clouds + "-" +
                                                  myWeather.main.humidity +
                                                  myWeather.main.temp_max + "-" + myWeather.main.pressure + "-"
                                                  +  "-" + myWeather.wind;
            string icon=String.Format("https://openweathermap.org/img/w/{0}.png",myWeather.weather[0].icon);
            MyImage.Source=new BitmapImage(new Uri(icon,UriKind.Absolute));
        }
    }
}
