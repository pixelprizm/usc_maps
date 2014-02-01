using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media; // for SolidColorBrush
using Microsoft.Phone.Maps.Controls; // for MapOverlay and MapLayer
using System.Device.Location; // Provides the GeoCoordinate class.
using System.Windows;
using System.Windows.Controls;

namespace usc_map
{
	public class UscPlace
	{
		public string Name { get; set; }
		public string BuildingCode { get; set; }
		public string Description { get; set; }

		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public Grid MapItem { get; set; }



		// public enum PlaceType { Event, Food, Study };
		// public PlaceType Type { get; set; }



		/// <summary>
		/// For instantiation for the hard-coded list
		/// </summary>
		/// <param name="name"></param>
		/// <param name="buildingCode"></param>
		/// <param name="description"></param>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		public UscPlace(MainPage mainPage, string name, string buildingCode, string description, double latitude, double longitude)
		{
			Name = name;
			BuildingCode = buildingCode;
			Description = description;
			Latitude = latitude;
			Longitude = longitude;

			// Initialize this place's grid to show up on the map and format it
			// note: this stuff is from the following site: http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj207037(v=vs.105).aspx
			MapItem = new Grid();
			formatMapItemUnselected();
			MapItem.Tap += delegate(object sender, System.Windows.Input.GestureEventArgs e)
			{
				mainPage.selectPlace(this);
			};

			mainPage.addPlaceToMapLayer(this);
		}

		public void formatMapItemUnselected()
		{
			MapItem.Height = 12;
			MapItem.Width = 12;
			MapItem.Background = new SolidColorBrush(Color.FromArgb(255, 0, 180, 0));
		}

		public void formatMapItemSelected()
		{
			MapItem.Height = 24;
			MapItem.Width = 24;
			MapItem.Background = new SolidColorBrush(Color.FromArgb(255, 180, 0, 0));
		}
	}
}
