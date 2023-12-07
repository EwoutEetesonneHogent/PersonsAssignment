using PersonsAssignment.Domain;

namespace PersonsAssignment.WPF
{
	public class PeopleApplication
	{
		private readonly DomainManager _domainManager;
		public PeopleApplication(DomainManager manager)
		{
			_domainManager = manager;
		}
	}
}
