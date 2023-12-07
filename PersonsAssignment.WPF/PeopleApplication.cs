using PersonsAssignment.Domain;

namespace PersonsAssignment.WPF
{
	public class PeopleApplication
	{
		private readonly DomainManager _domainManager;
		private PeopleWindow _peopleWindow;
		public PeopleApplication(DomainManager manager)
		{
			_domainManager = manager;
			_peopleWindow = new();
			_peopleWindow.Show();

			_peopleWindow.People = _domainManager.GetAllPersons();
		}
	}
}