using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usc_map
{
	static class SearchPlaceCollection
	{
		public static List<UscPlace> PlaceList { get; private set; }

		static SearchPlaceCollection()
		{
			PlaceList = new List<UscPlace>();
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
