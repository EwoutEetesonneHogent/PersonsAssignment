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

		public void CreatePerson(string name, string email, DateTime birthDate)
		{
			
			_personRepository.CreatePerson(new(name,email,birthDate));

		}

        public void RemovePerson(PersonIdArgs e)
        {
			_personRepository.DeletePerson(e.Id);
        }

        public string GetPersonNameById(int id)
        {
            return _personRepository.GetPersonById(id).Name;
        }

        public string GetPersonEmailById(int id)
        {
            return _personRepository.GetPersonById(id).Email;
        }

        public DateTime GetPersonBirthDateById(int id)
        {
            return _personRepository.GetPersonById(id).BirthDate;
        }
    }
}