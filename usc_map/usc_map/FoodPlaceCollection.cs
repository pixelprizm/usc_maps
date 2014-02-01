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
			PlaceList.Add(new UscPlace(mainPage, "food", "LiteraTea and Nazarian Pavilion", "", "Located adjacent to the Doheny Library courtyard, Nazarian Pavilion houses the LiteraTea Teahouse, which features indoor and outdoor seating.", 34.020075, -118.283480));
			PlaceList.Add(new UscPlace(mainPage, "food", "Tutor Hall Cafe", "RTH", "Located on the ground level of Tutor Hall, this cafe features ethnic food, and both outdoor and indoor seating perfect for studying", 34.019915, -118.290008));
			PlaceList.Add(new UscPlace(mainPage, "food", "Law School Cafe", "LAW", "Located at the basement level of Musick Law Building, this cafe serves breakfast and lunch as well as an assortment of beverages and \"grab-and-go\" selections. Also a great place for studying.", 34.018657, -118.284590));
			PlaceList.Add(new UscPlace(mainPage, "food", "Cafe 84", "KOH", "Just a few steps from the Lyon Center, Café 84 Residential Facility offers healthy choices in an exhibition-style format, as well as an extensive salad and sandwich bar.", 34.024641, -118.288109));
			PlaceList.Add(new UscPlace(mainPage, "food", "Popovich Cafe", "JKP", "Located on the ground floor of Popovich Hall, Popovich Cyber Cafe serves three meals a day, along with sandwiches, coffee, smoothies and a variety of packaged goods. It features flat-screen TVs and also provides wireless Internet service at tables located indoors as well as in the courtyard.", 34.018901, -118.282691));
			PlaceList.Add(new UscPlace(mainPage, "food", "URBNMRKT", "CAL", "URBNMRKT is a full-service cafe offering made-to-order breakfast and lunch items, grab-and-go food, fresh-brewed coffee and custom-made espresso drinks.", 34.019186, -118.276543));
			PlaceList.Add(new UscPlace(mainPage, "food", "Shop Cafe and Nekter Juice Bar", "HAR", "Located in the west wing of the Harris Hall complex, the Shop Cafe features grilled panini sandwiches, salads, pastries, teas and coffee. Nekter serves all-natural, raw, vegan juices and smoothies.", 34.019017, -118.287642));
			PlaceList.Add(new UscPlace(mainPage, "food", "Everybody's Kitchen", "EVK", "Located adjacent to Birnkrant and New Residential Colleges, EVerybody's Kitchen (EVK) offers American cuisine entrees, Mexican and vegetarian stations, sandwiches, salads and desserts.", 34.021404, -118.282106));
			PlaceList.Add(new UscPlace(mainPage, "food", "Parkside Restaurant", "IRC", "Parkside Restaurant, located in the International Residential College at Parkside, serves international cuisine specialties from four exhibition stations and also offers vegetarian selections, kosher meals, sandwiches and salads.", 34.018839, -118.290990));
			PlaceList.Add(new UscPlace(mainPage, "food", "Trojan Grounds and Starbucks", "BSR", "Located adjacent to Leavey Library and EVerybody’s Kitchen, Trojan Grounds features Starbucks coffees and \"grab-and-go\" sandwiches, salads and desserts as well as convenience items – and is open 24 hours a day.", 34.021255, -118.282447));
			PlaceList.Add(new UscPlace(mainPage, "food", "Tutor Campus Center", "TCC", "California Pizza Kitchen (CPK), Panda Express, Verde, The Habit, Lemonade, Seeds. Seeds serves hot food, sandwiches, and salads.", 34.020215, -118.286492));
			PlaceList.Add(new UscPlace(mainPage, "food", "Ground Zero Performance Café", "TRO", "Ground Zero Performance Café is a student-run coffeehouse and performance space located in the quad between Marks and Trojan residential halls. Café is open until midnight.", 34.019552, -118.282291));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Chipotle", "", "Burritos and burrito bowls with free-range meats and lots of options. Try an off-the-menu secret, a quesarrito (burrito and quesadilla cross-breed) and you won't be disappointed!", 34.016707, -118.282575));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Chick-Fil-A", "", "Famous chicken sandwiches, waffle fries, and more. Make sure to come on Trojan Tuesdays to get sweet deals like free chicken sandwiches after 6pm.", 34.016578, -118.282591));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Lotus", "", "Tucked away behind Tuscany is this sushi and hookah bar. Hookah bar floor seating is rad, but if you're not looking to practice your smoke rings, there's also a dining room for non-hookah partakers. Try their small tea pots or share one with a friend- they're beautiful and delicious.", 34.017493, -118.281181));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Cups of Coffee", "", "Satisfy your coffee and espresso dreams right across the street from campus. This new coffee joint has reasonable prices and serves Groundwork coffee. Added bonus: also a great place to study or meet up with friends. Tip: Always order it to go (even if you're planning on hanging out) and you won't get charged for taxes.", 34.022251, -118.279904));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Freebirds", "", "Great burritos and more. Often considered second rate to Chipotle, but they do have more options than Chipotle. Grab a \"pot brownie\" and a burrito for a quick dinner right off campus.", 34.022224, -118.280108));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Subway", "", "Your average Subway. Open late (2:30am)often.", 34.022802, -118.279572));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Pizza Studio", "", "Great thin crust personal pizzas line-style. Unlimited toppings for $8.", 34.018765, -118.281557));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Which Wich", "", "Sandwiches and great milkshakes. Tons of options. Try their Oreo milkshake", 34.018552, -118.281481));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Taco Bell", "", "Taco Bell on the west side of campus.", 34.022349, -118.291781));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Manas Indian Restaurant", "", "Great Indian food", 34.028955, -118.291792));
			PlaceList.Add(new UscPlace(mainPage, "foodoff", "Ignatius Cafe", "", "One of the USC area's best kept secrets. Best lattes in walking distance of USC($3 donation, beans are carefully picked, roasted, and ground in-house). It is inside an old house that is now turned into all study rooms and owned by the Korean Catholic Church next door. Outside seating is beautiful. Hard to find from the street, but when you do, you'll be amazed.", 34.031792, -118.292940));
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
