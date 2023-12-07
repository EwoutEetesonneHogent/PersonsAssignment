using PersonsAssignment.Domain.Repository;

namespace PersonsAssignment.Domain
{
	public class DomainManager
	{
		private readonly IPersonsRepository _personRepository;

		public DomainManager(IPersonsRepository personRepository)
		{
			_personRepository = personRepository;
		}
	}
}