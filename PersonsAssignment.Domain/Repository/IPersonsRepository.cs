using PersonsAssignment.Domain.Model;

namespace PersonsAssignment.Domain.Repository
{
	public interface IPersonsRepository
	{
		int CountPeople();
		int CreatePerson(Person person);
		void DeletePerson(int id);
		List<Person> GetAllPeople();
		Person GetPersonById(int id);
		void UpdatePerson(Person person);
	}
}
