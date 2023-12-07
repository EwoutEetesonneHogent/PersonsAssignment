using PersonsAssignment.Domain;

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
		}
	}
}