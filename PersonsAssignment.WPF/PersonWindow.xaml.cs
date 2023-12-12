using System;
using System.Windows;

namespace PersonsAssignment.WPF
{
	/// <summary>
	/// Interaction logic for PersonWindow.xaml
	/// </summary>
	public partial class PersonWindow : Window
	{
		public event EventHandler<PersonSubmittedEventArgs> PersonSubmitted;
		public PersonWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (BirthdayCalendar.SelectedDate is DateTime date && 
				!string.IsNullOrWhiteSpace(NameText.Text) && 
				!string.IsNullOrWhiteSpace(EmailText.Text))
			{
				PersonSubmitted?.Invoke(this, new PersonSubmittedEventArgs(NameText.Text, EmailText.Text, date));
			}
			else
			{
				MessageBox.Show("Please enter all values");
			}
		}
	}

	public class PersonSubmittedEventArgs : EventArgs
	{
		public PersonSubmittedEventArgs(string name, string email, DateTime birthDay)
		{
			Name = name;
			Email = email;
			BirthDay = birthDay;
		}

		public string Name { get; init; }
		public string Email { get; init; }
		public DateTime BirthDay { get; init; }
	}
}