using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usc_map
{
	static class EventPlaceCollection
	{
		public static List<UscPlace> PlaceList { get; private set; }

		static EventPlaceCollection()
		{
			PlaceList = new List<UscPlace>();
		}

		public static void addAllEventPlaces(MainPage mainPage)
		{
			PlaceList.Add(new UscPlace(mainPage, "event", "Manas Indian Restaurant", "", "Great Indian food", 34.028955, -118.291792));
			PlaceList.Add(new UscPlace(mainPage, "event", "Ignatius Cafe", "", "One of the USC area's best kept secrets. Best lattes in walking distance of USC($3 donation, beans are carefully picked, roasted, and ground in-house). It is inside an old house that is now turned into all study rooms and owned by the Korean Catholic Church next door. Outside seating is beautiful. Hard to find from the street, but when you do, you'll be amazed.", 34.031792, -118.292940));
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
