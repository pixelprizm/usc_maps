using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usc_map
{
	static class FoodPlaceCollection
	{
		public static List<UscPlace> PlaceList { get; private set; }

		static FoodPlaceCollection()
		{
			PlaceList = new List<UscPlace>();

		}

		public static void addAllFoodPlaces(MainPage mainPage)
		{
			PlaceList.Add(new UscPlace(mainPage, "Test", "TST", "This is a test", 34.023956, -118.285449));
			PlaceList.Add(new UscPlace(mainPage, "Test2", "TS2", "This is another test", 34.019215, -118.291241));
		}

		/// <summary>
		/// Switches the visibility of all UscPlace in PlaceList to the opposite of the first one.
		/// </summary>
		public static void toggleMapVisibility()
		{
			if (PlaceList.Count != 0)
			{
				if (PlaceList[0].MapItem.Visibility == System.Windows.Visibility.Collapsed)
				{
					foreach (UscPlace p in PlaceList)
					{
						p.MapItem.Visibility = System.Windows.Visibility.Visible;
					}
				}
				else
				{
					foreach (UscPlace p in PlaceList)
					{
						p.MapItem.Visibility = System.Windows.Visibility.Collapsed;
					}
				}
			}
		}
	}
}
