using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;


namespace appSafeWalker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        double longitud = -74.2973328;
        double latitud = 4.570868;
        string ubicacion;
        public MainPage()
        {
            InitializeComponent();
            MostrarMapa();
        }
        private void MostrarMapa()
        {
            int pros = 0;
            pros += 1;
            if (ingUbicacion.Text != "Ingrese ubicación")
                if (ingUbicacion != null)
                    Localizar();
                else
                    Gps();
            //                if(ingUbicacion.Text!=null)
            //                  if(ingUbicacion.Text != "")

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitud, longitud), Distance.FromKilometers(1)));
            Console.WriteLine(pros);
        }
        private async void Gps()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 30;
            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                    }
                locator.PositionChanged += (cambio, args) =>
                {
                    var loc = args.Position;
                    longitud = loc.Longitude;
                    latitud = loc.Latitude;
                };
            }
        }
        private async void Localizar()
        {
            try
            {
                ubicacion = ingUbicacion.Text;
                var locations = await Geocoding.GetLocationsAsync(ubicacion);

                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    longitud = location.Longitude;
                    latitud = location.Latitude;

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
            }
        }
    }
}
