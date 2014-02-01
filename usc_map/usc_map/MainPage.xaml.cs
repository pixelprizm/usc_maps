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
using System.IO;

using Windows.Devices.Geolocation; //Provides the Geocoordinate class.
using System.Windows.Shapes;
using ShowMyLocationOnMap;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

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
			_foodToggle.IconUri = new Uri("/Assets/food_selected.png", UriKind.Relative);
			_foodToggle.Text = "food";
			_foodToggle.Click += _foodToggle_Click;
			ApplicationBar.Buttons.Add(_foodToggle);

			_studySpaceToggle = new ApplicationBarIconButton();
			_studySpaceToggle.IconUri = new Uri("/Assets/study_selected.png", UriKind.Relative);
			_studySpaceToggle.Text = "study";
			_studySpaceToggle.Click += _studySpaceToggle_Click;
			ApplicationBar.Buttons.Add(_studySpaceToggle);

			_eventsToggle = new ApplicationBarIconButton();
			_eventsToggle.IconUri = new Uri("/Assets/events_selected.png", UriKind.Relative);
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
            searchBox.Text = "";

            request.BeginGetResponse(ReadCallback, request);
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[16*1024];
            int read;
            while((read = input.Read (buffer, 0, buffer.Length) ) > 0) {
                output.Write (buffer, 0, read);
            }
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

                 //   [{"location_id":"15","map_name":"Grace Ford Salvatori Hall","building_code":"GFS","lat":"34.0213356018","lng":"-118.2880020142"}]

                    
                    string[] words = resultText.Split(',');

                    List<MapApiObject> objectList = new List<MapApiObject>();


                    var mo = new MapApiObject();
                    
                    foreach (string s in words) {
                        var t = s.Split(':');
                        var z = t[0].IndexOf('"');
                        var y = t[0].Substring(z + 1, (t[0].Length) - z - 2);

                        var z2 = t[1].IndexOf('"');
                        var yt = t[1].Substring(z2 + 1, (t[1].Length) - z2 - 2);
                        var y2l = yt.IndexOf('"');
                        var y2 = y2l > 0 ? yt.Substring(0, y2l) : yt;

                        switch (y)
                        {
                            case "location_id":
                            {
                                mo.location_id = int.Parse(y2);
                                break;
                            }
                            case "map_name":
                            {
                                mo.map_name = y2;
                                break;
                            }
                            case "building_code":
                            {
                                mo.building_code = y2;
                                break;
                            }
                            case "lat":
                            {
                                mo.lat = double.Parse(y2);
                                break;
                            }
                            case "lng":
                            {
                                mo.lng = double.Parse(y2);

                                
                                objectList.Add(mo);
                                mo = new MapApiObject();
                                break;
                            }
                            default: break;
                        }
                            
                    }
                    // Now send that object list somewhere


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

			DescriptionPanelTitle.Text = "";
			DescriptionPanelBuildingCode.Text = "";
			DescriptionPanelDescription.Text = "";

			_selectedPlace = placeToSelect;

			if (_selectedPlace != null)
			{
				_selectedPlace.formatMapItemSelected();

				DescriptionPanelTitle.Text = _selectedPlace.Name;
				DescriptionPanelBuildingCode.Text = _selectedPlace.BuildingCode;
				DescriptionPanelDescription.Text = _selectedPlace.Description;
			}
		}



		void _studySpaceToggle_Click(object sender, EventArgs e)
		{
			StudyPlaceCollection.toggleMapVisibility();

			if (StudyPlaceCollection.PlaceList.Count != 0)
			{
				if (StudyPlaceCollection.PlaceList[0].MapItem.Visibility == Visibility.Collapsed)
				{
					_studySpaceToggle.IconUri = new Uri("/Assets/study_unselected.png", UriKind.Relative);
				}
				else
				{
					_studySpaceToggle.IconUri = new Uri("/Assets/study_selected.png", UriKind.Relative);
				}
			}
		}

		void _foodToggle_Click(object sender, EventArgs e)
		{
			FoodPlaceCollection.toggleMapVisibility();

			if (FoodPlaceCollection.PlaceList.Count != 0)
			{
				if (FoodPlaceCollection.PlaceList[0].MapItem.Visibility == Visibility.Collapsed)
				{
					_foodToggle.IconUri = new Uri("/Assets/food_unselected.png", UriKind.Relative);
				}
				else
				{
					_foodToggle.IconUri = new Uri("/Assets/food_selected.png", UriKind.Relative);
				}
			}
		}

		void _eventsToggle_Click(object sender, EventArgs e)
		{
			EventPlaceCollection.toggleMapVisibility();

			if (EventPlaceCollection.PlaceList.Count != 0)
			{
				if (EventPlaceCollection.PlaceList[0].MapItem.Visibility == Visibility.Collapsed)
				{
					_eventsToggle.IconUri = new Uri("/Assets/events_unselected.png", UriKind.Relative);
				}
				else
				{
					_eventsToggle.IconUri = new Uri("/Assets/events_selected.png", UriKind.Relative);
				}
			}
		}

	}
}