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
		public event EventHandler<PersonIdArgs> RemoveingPerson;

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
				int id = GetIdFromSelection(PeopleListBox.SelectedItem.ToString());
                if (id>0) RemoveingPerson?.Invoke(this, new(id));
            }
        }

		private int GetIdFromSelection(string input)
		{
			try 
			{
                int startIndex = input.IndexOf('[');
                int endIndex = input.IndexOf(']');
                return int.Parse(input.Substring(startIndex + 1, endIndex - startIndex - 1));
            }catch(Exception)
			{
				MessageBox.Show($"could not get Person Id from the selected person: \n{input}");
				return -1;
			}
			
        }
 
    }
}
