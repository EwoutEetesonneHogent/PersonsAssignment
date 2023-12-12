using PersonsAssignment.Domain.Model;
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

		public List<string> GetAllPersons()
		{
			return _personRepository.GetAllPeople().Select(p => p.ToString()).ToList();
		}

		public void SavePerson(string name, string email, DateTime birthDay)
		{
			Person person = new(name, email, birthDay);
			_personRepository.CreatePerson(person);
		}
	}
}