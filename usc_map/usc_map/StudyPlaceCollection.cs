using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usc_map
{
	static class StudyPlaceCollection
	{
		public static List<UscPlace> PlaceList { get; private set; }

		static StudyPlaceCollection()
		{
			PlaceList = new List<UscPlace>();

		}

		public static void addAllStudyPlaces(MainPage mainPage)
		{
			PlaceList.Add(new UscPlace(mainPage, "study", "Accounting Library", "ACC", "Located in room 105 of the Leventhal School of Accounting building, this library serves the educational and research needs of accounting students and faculty.", 34.018974, -118.286010));
			PlaceList.Add(new UscPlace(mainPage, "study", "Architecture and Fine Arts Library", "AFA", "The Architecture and Fine Arts (AFA) Library is located on the ground floor (basement) of Watt Hall (WAH). Watt Hall's entry doors face the courtyard. Go in and take any stairwell or elevator down to reach the ground floor.", 34.019267, -118.287803));
			PlaceList.Add(new UscPlace(mainPage, "study", "Crocker Business Library", "HOH", "Located on the second floor of Hoffman Hall, the Roy P. Crocker Business Library serves students and faculty of the USC Marshall School of Business.", 34.018589, -118.285277));
			PlaceList.Add(new UscPlace(mainPage, "study", "Cinematic Arts Library", "DML", "Located inside Doheny Memorial Library", 34.020292, -118.283982));
			PlaceList.Add(new UscPlace(mainPage, "study", "Doheny Memorial Library", "DML", "Doheny Memorial Library holds vast collections of books and journals and hosts academic and cultural events ranging from lectures, readings and conferences to special exhibits and concerts.", 34.020292, -118.283982));
			PlaceList.Add(new UscPlace(mainPage, "study", "Gerontology Library", "GER", "Located in the Andrus Gerontology Center building, USC’s Gerontology Library maintains a collection of research materials focused on the sociological, psychological and physical aspects of aging. The library is open to the public; however, preference is given to USC students during busy periods.", 34.020328, -118.290388));
			PlaceList.Add(new UscPlace(mainPage, "study", "Leavey Library", "LVL", "Leavey Library is a dedicated library for undergraduate students and is open 24 hours a day, except from midnight to 9 a.m. on Sunday, when classes are in session.", 34.021724, -118.282920));
			PlaceList.Add(new UscPlace(mainPage, "study", "Hoose Library of Philosophy", "MHP", "Hoose Library of Philosophy houses a collection of more than 50,000 volumes serving the educational and research needs of graduates, undergraduate students, and faculty.", 34.018617, -118.286773));
			PlaceList.Add(new UscPlace(mainPage, "study", "Seaver Science and Engineering Library", "SSL", "The Science & Engineering Library provides resources for the life sciences, earth sciences, physical sciences, mathematics and engineering.", 34.019506, -118.288801));
			PlaceList.Add(new UscPlace(mainPage, "study", "VKC Library", "VKC", "Located in the basement of the Von KleinSmid Center, the Von KleinSmid Center Library is a graduate-level research and learning center focused on political science, international relations, public administration, and urban and regional planning.", 34.020973, -118.283743));
			PlaceList.Add(new UscPlace(mainPage, "study", "LiteraTea and Nazarian Pavilion", "", "Located adjacent to the Doheny Library courtyard, Nazarian Pavilion houses the LiteraTea Teahouse, which features indoor and outdoor seating.", 34.020075, -118.283480));
			PlaceList.Add(new UscPlace(mainPage, "study", "Cinematic Arts Quad", "", "Grassy outdoor area in the School of Cinematic Arts with benches and lawn to study or read on. ", 34.023659, -118.287213));
			PlaceList.Add(new UscPlace(mainPage, "study", "Tutor Hall Cafe", "RTH", "Located on the ground level of Tutor Hall, this cafe features ethnic food, and both outdoor and indoor seating perfect for studying", 34.019915, -118.290008));
			PlaceList.Add(new UscPlace(mainPage, "study", "Law School Cafe", "LAW", "Located at the basement level of Musick Law Building, this cafe serves breakfast and lunch as well as an assortment of beverages and \"grab-and-go\" selections. Also a great place for studying.", 34.018657, -118.284590));
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
