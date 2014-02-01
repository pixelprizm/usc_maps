using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using usc_map.Resources;

namespace usc_map
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			textbox0.Text = "you clicked me";
		}
	}
}