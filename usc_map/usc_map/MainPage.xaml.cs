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
using Microsoft.Phone.Maps.Controls; // for putting controls on the map
using System.Device.Location; // for gps I guess
using usc_map.Resources;
using System.Windows.Threading; // for timer
using System.Windows.Media; // for SolidColorBrush

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
			_eventsToggle.IconUri = new Uri("/Assets/events.png", UriKind.Relative);
			_eventsToggle.Text = "events";
			ApplicationBar.Buttons.Add(_eventsToggle);

			_foodToggle = new ApplicationBarIconButton();
			_foodToggle.IconUri = new Uri("/Assets/food1.png", UriKind.Relative);
			_foodToggle.Text = "food";
			ApplicationBar.Buttons.Add(_foodToggle);

			_studySpaceToggle = new ApplicationBarIconButton();
			_studySpaceToggle.IconUri = new Uri("/Assets/study.png", UriKind.Relative);
			_studySpaceToggle.Text = "study spaces";
			ApplicationBar.Buttons.Add(_studySpaceToggle);


            this.Loaded += MainPage_Loaded;

			initializeMapOverlays();
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




		private void initializeMapOverlays()
		{
			// note: this stuff is from the following site: http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj207037(v=vs.105).aspx

			Grid newGrid = new Grid();
			newGrid.Height = 12;
			newGrid.Width = 12;
			newGrid.Background = new SolidColorBrush(Color.FromArgb(255, 127, 127, 127));
		}
	}
}