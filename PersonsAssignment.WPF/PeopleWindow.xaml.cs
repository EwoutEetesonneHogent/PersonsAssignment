using System;
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
		public event EventHandler AddingPerson;
		public PeopleWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AddingPerson?.Invoke(this, EventArgs.Empty);
		}

        private void PeopleListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
			MessageBox.Show("you doubleclicked :)");
        }
    }
}
