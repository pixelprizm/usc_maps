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
			PlaceList.Add(new UscPlace(mainPage, "event", "MFA Open Studios: 2/1 5:00pm-10:00pm", "HAR", "The faculty and students of the USC Roski School of Fine Art invite you to the 2014 MFA Open Studios. Sixteen students will have their studios on display, offering a look into each student’s individual practice.", 34.019086, -118.287884));
			PlaceList.Add(new UscPlace(mainPage, "event", "Creating & Coordinating the Global Initiative for Fiscal Transparency 2/3 12:00PM - 2:00PM", "VKC", "Please join us for a discussion with Sanjeev Khagram, John Parke Young Professor of Global Political Economy at Occidental College.", 34.021017, -118.284216));
			PlaceList.Add(new UscPlace(mainPage, "event", "A Lecture and Demonstration on Shakespeare with Rob Clare 2/4 6:00PM - 7:30PM", "MCL", "Reservation required. Internationally acclaimed master-teacher and Shakespearian performance expert Rob Clare (Royal Shakespeare Company) demonstrates the extraordinary richness, dynamism and modernity of Shakespeare's texts.", 34.025061, -118.287692));
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
