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

using Windows.Devices.Geolocation; //Provides the Geocoordinate class.
using System.Windows.Shapes;
using ShowMyLocationOnMap;

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
			_eventsToggle.IconUri = new Uri("/Assets/whiteevents.png", UriKind.Relative);
			_eventsToggle.Text = "events";
			_eventsToggle.Click += _eventsToggle_Click;
			ApplicationBar.Buttons.Add(_eventsToggle);

			_foodToggle = new ApplicationBarIconButton();
			_foodToggle.IconUri = new Uri("/Assets/whitefood1.png", UriKind.Relative);
			_foodToggle.Text = "food";
			ApplicationBar.Buttons.Add(_foodToggle);

			_studySpaceToggle = new ApplicationBarIconButton();
			_studySpaceToggle.IconUri = new Uri("/Assets/whitestudy.png", UriKind.Relative);
			_studySpaceToggle.Text = "study";
			_studySpaceToggle.Click += _studySpaceToggle_Click;
			ApplicationBar.Buttons.Add(_studySpaceToggle);

			ShowMyLocationOnTheMap();


			this.Loaded += MainPage_Loaded;

			initializeMapData();
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

		private async void ShowMyLocationOnTheMap()
		{
			Geolocator myGeolocator = new Geolocator();
			Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
			Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
			GeoCoordinate myGeoCoordinate =
			CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);

			//this.uscMap.Center = myGeoCoordinate;
			//this.uscMap.ZoomLevel = 16;

			// Create a small circle to mark the current location.
			Ellipse myCircle = new Ellipse();
			myCircle.Fill = new SolidColorBrush(Color.FromArgb(255, 0x99, 0x00, 0x00));
			myCircle.Height = 15;
			myCircle.Width = 15;
			myCircle.Opacity = 50;

			// Create a MapOverlay to contain the circle.
			MapOverlay myLocationOverlay = new MapOverlay();
			myLocationOverlay.Content = myCircle;
			myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
			myLocationOverlay.GeoCoordinate = myGeoCoordinate;

			// Create a MapLayer to contain the MapOverlay.
			MapLayer myLocationLayer = new MapLayer();
			myLocationLayer.Add(myLocationOverlay);

			// Add the MapLayer to the Map.
			uscMap.Layers.Add(myLocationLayer);
		}



		MapLayer _mapLayer = new MapLayer();
		private void initializeMapData()
		{
			// Note that the following method involves creating all the study places and they each call the addPlaceToMapLayer method.
			StudyPlaceCollection.addAllStudyPlaces(this);

			uscMap.Layers.Add(_mapLayer);
		}



		void _eventsToggle_Click(object sender, EventArgs e)
		{
		}

		void _studySpaceToggle_Click(object sender, EventArgs e)
		{
			StudyPlaceCollection.toggleMapVisibility();
		}



		public void addPlaceToMapLayer(UscPlace newPlace)
		{
			MapOverlay newMapOverlay = new MapOverlay();

			newMapOverlay.Content = newPlace.MapItem;
			newMapOverlay.GeoCoordinate = new GeoCoordinate(newPlace.Latitude, newPlace.Longitude);
			newMapOverlay.PositionOrigin = new Point(0.5, 0.5);
			_mapLayer.Add(newMapOverlay);
		}



		private UscPlace _selectedPlace;
		public void selectPlace(UscPlace placeToSelect)
		{
			_selectedPlace.formatMapItemUnselected();

			_selectedPlace = placeToSelect;

			_selectedPlace.formatMapItemSelected();
		}
	}
}