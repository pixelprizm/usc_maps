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
using System.Threading.Tasks;
using System.IO;

namespace usc_map
{
	public partial class MainPage : PhoneApplicationPage
	{
		// App Bar stuff:
		ApplicationBarIconButton _foodToggle;
		ApplicationBarIconButton _studySpaceToggle;
		ApplicationBarIconButton _eventsToggle;

		// Constructor
		public MainPage()
		{

			InitializeComponent();

			ApplicationBar = new ApplicationBar();
			ApplicationBar.Mode = ApplicationBarMode.Default;
			ApplicationBar.IsVisible = true;

			_foodToggle = new ApplicationBarIconButton();
			_foodToggle.IconUri = new Uri("/Assets/food_unselected.png", UriKind.Relative);
			_foodToggle.Text = "food";
			_foodToggle.Click += _foodToggle_Click;
			ApplicationBar.Buttons.Add(_foodToggle);

			_studySpaceToggle = new ApplicationBarIconButton();
			_studySpaceToggle.IconUri = new Uri("/Assets/study_unselected.png", UriKind.Relative);
			_studySpaceToggle.Text = "study";
			_studySpaceToggle.Click += _studySpaceToggle_Click;
			ApplicationBar.Buttons.Add(_studySpaceToggle);

			_eventsToggle = new ApplicationBarIconButton();
			_eventsToggle.IconUri = new Uri("/Assets/events_unselected.png", UriKind.Relative);
			_eventsToggle.Text = "events";
			_eventsToggle.Click += _eventsToggle_Click;
			ApplicationBar.Buttons.Add(_eventsToggle);

			ShowMyLocationOnTheMap();



			initializeMapData();
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

        // Here we're gonna load those external API calls to UscMaps
        void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string webUri = "http://web-app.usc.edu/ws/uscmap/api?search=" + Uri.EscapeDataString(searchBox.Text);
            HttpWebRequest request =
                (HttpWebRequest)HttpWebRequest.Create(webUri);
            //searchBox.Text = "" + webUri;

            request.BeginGetResponse(ReadCallback, request);

        }

        // This is a callback function for the UscMaps API.  You remember those from your web design days, right?
        private void ReadCallback(IAsyncResult result)
        {
            string resultText = "";
            //searchBox.Text = "weeeee";
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);

                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    resultText = reader.ReadToEnd();
                    Console.Write(resultText);
                }
                catch (Exception e)
                {
                    resultText = "Gamertag not found.";
                    searchBox.Text = "" + resultText;
                    return;
                }
            }

        }



		MapLayer _mapLayer = new MapLayer();
		private void initializeMapData()
		{
			// Note that the following methods involvs creating all the places and they each call the addPlaceToMapLayer method.
			StudyPlaceCollection.addAllStudyPlaces(this);
			FoodPlaceCollection.addAllFoodPlaces(this);
			EventPlaceCollection.addAllEventPlaces(this);

			uscMap.Layers.Add(_mapLayer);
		}

		public void addPlaceToMapLayer(UscPlace newPlace)
		{
			MapOverlay newMapOverlay = new MapOverlay();

			newMapOverlay.Content = newPlace.MapItem;
			newMapOverlay.GeoCoordinate = new GeoCoordinate(newPlace.Latitude, newPlace.Longitude);
			newMapOverlay.PositionOrigin = new Point(0.5, 0.5);
			_mapLayer.Add(newMapOverlay);
		}



		private UscPlace _selectedPlace = null;
		public void selectPlace(UscPlace placeToSelect)
		{
			if (_selectedPlace != null)
			{
				_selectedPlace.formatMapItemUnselected();
			}

			_selectedPlace = placeToSelect;

			if (_selectedPlace != null)
			{
				_selectedPlace.formatMapItemSelected();
			}
		}



		void _studySpaceToggle_Click(object sender, EventArgs e)
		{
			StudyPlaceCollection.toggleMapVisibility();
		}

		void _foodToggle_Click(object sender, EventArgs e)
		{
			FoodPlaceCollection.toggleMapVisibility();
		}

		void _eventsToggle_Click(object sender, EventArgs e)
		{
			EventPlaceCollection.toggleMapVisibility();
		}

	}
}