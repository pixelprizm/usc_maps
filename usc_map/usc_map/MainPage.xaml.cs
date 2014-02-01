using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell; // for App Bar
using Microsoft.Phone.Maps.Toolkit;
using usc_map.Resources;
using System.Windows.Threading; // for timer

namespace usc_map
{
	public partial class MainPage : PhoneApplicationPage
	{
		// App Bar stuff:
		ApplicationBarIconButton _eventsToggle;
		ApplicationBarIconButton _foodToggle;
		ApplicationBarIconButton _studySpaceToggle;


		// Constructor
		public MainPage()
		{

			InitializeComponent();

			ApplicationBar = new ApplicationBar();
			ApplicationBar.Mode = ApplicationBarMode.Default;
			ApplicationBar.IsVisible = true;

			_eventsToggle = new ApplicationBarIconButton();
			_eventsToggle.IconUri = new Uri("/Assets/feature.search.png", UriKind.Relative);
			_eventsToggle.Text = "events";
			ApplicationBar.Buttons.Add(_eventsToggle);

			_foodToggle = new ApplicationBarIconButton();
			_foodToggle.IconUri = new Uri("/Assets/feature.search.png", UriKind.Relative);
			_foodToggle.Text = "food";
			ApplicationBar.Buttons.Add(_foodToggle);

			_studySpaceToggle = new ApplicationBarIconButton();
			_studySpaceToggle.IconUri = new Uri("/Assets/feature.search.png", UriKind.Relative);
			_studySpaceToggle.Text = "study spaces";
			ApplicationBar.Buttons.Add(_studySpaceToggle);


            this.Loaded += MainPage_Loaded;
                
            
		}

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer t = new DispatcherTimer(); 
            t.Interval = TimeSpan.FromMilliseconds(2000);
            t.Tick += loadUserLocation;
            t.Start();
        }


        void loadUserLocation(object sender, EventArgs e)  
        {
          // firstMarker.GeoCoordinate = uscMap.Center;

           // UserLocationMarker marker = (UserLocationMarker)this.FindName("firstMarker");
           // marker.GeoCoordinate = uscMap.Center;

            //Pushpin pushpin = (Pushpin)uscMap.FindName("MyPushpin");
            //pushpin.GeoCoordinate = new System.Device.Location.GeoCoordinate(34.023958, -118.285449);
        }
        //void uscMap_Loaded(object sender, RoutedEventArgs e)
        //{
        //    firstMarker.GeoCoordinate = uscMap.Center;

        //    UserLocationMarker marker = (UserLocationMarker)this.FindName("firstMarker");
        //    marker.GeoCoordinate = uscMap.Center;

        //    //Pushpin pushpin = (Pushpin)uscMap.FindName("MyPushpin");
        //    //pushpin.GeoCoordinate = new System.Device.Location.GeoCoordinate(34.023958, -118.285449);
        //}

      


	}
}