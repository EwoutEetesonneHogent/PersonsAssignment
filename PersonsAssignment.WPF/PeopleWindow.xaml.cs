using System.Collections.Generic;
using System.Windows;

namespace PersonsAssignment.WPF
{
	/// <summary>
	/// Interaction logic for PeopleWindow.xaml
	/// </summary>
	public partial class PeopleWindow : Window
	{
		public List<string> People { set => PeopleListBox.ItemsSource = value; }
		public PeopleWindow()
		{
			InitializeComponent();
		}
	}
}
