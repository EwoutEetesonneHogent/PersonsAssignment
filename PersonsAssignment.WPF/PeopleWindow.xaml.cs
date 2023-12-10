using PersonsAssignment.Domain.Model;
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
		public event EventHandler<PersonToDeleteArgs> RemoveingPerson;
		public PeopleWindow()
		{
			InitializeComponent();
		}

		private void btnAddNewPerson_Click(object sender, RoutedEventArgs e)
		{
			AddingPerson?.Invoke(this, EventArgs.Empty);
		}

        private void PeopleListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
			MessageBox.Show("you doubleclicked someone");
        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
			if (PeopleListBox.SelectedIndex < 0 ) // No selection = -1
			{
                MessageBox.Show($"you have to select a person to delete!");
            } else
			{
                //MessageBox.Show($"you selected {PeopleListBox.SelectedIndex}");               
                RemoveingPerson?.Invoke(this, new(GetIdFromString(PeopleListBox.SelectedItem.ToString())));
            }
        }

		private string GetIdFromString(string input)
		{
            int startIndex = input.IndexOf('[');
            int endIndex = input.IndexOf(']');
			return input.Substring(startIndex + 1, endIndex - startIndex - 1);
        }
 
    }
}
