using PersonsAssignment.Domain;
using System;
using System.Windows;

namespace PersonsAssignment.WPF
{
	public class PeopleApplication
	{
		private readonly DomainManager _domainManager;
		private PeopleWindow _peopleWindow;
		private PersonWindow _personWindow;
		public PeopleApplication(DomainManager manager)
		{
			_domainManager = manager;
			_peopleWindow = new();
			_peopleWindow.AddingPerson += AddingPerson;
			_peopleWindow.Show();

			_peopleWindow.People = _domainManager.GetAllPersons();
		}

		private void AddingPerson(object? sender, System.EventArgs e)
		{
			_personWindow = new PersonWindow();
			_personWindow.Show();
			_personWindow.PersonSubmitted += _personWindow_PersonSubmitted;
		}

		private void _personWindow_PersonSubmitted(object? sender, PersonSubmittedEventArgs e)
		{
			try
			{
				_domainManager.SavePerson(e.Name, e.Email, e.BirthDay);
				_personWindow.PersonSubmitted -= _personWindow_PersonSubmitted;
				_personWindow.Close();

				_peopleWindow.People = _domainManager.GetAllPersons();
			}
			catch (ApplicationException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}