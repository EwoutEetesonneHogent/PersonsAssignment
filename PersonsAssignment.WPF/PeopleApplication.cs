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

			ShowUpdatedPeopleWindow();

        }

		private void AddingPerson(object? sender, System.EventArgs e)
		{
			_personWindow = new PersonWindow();
            _personWindow.SavingNewPerson += AddedNewPerson;
            _peopleWindow.Hide();
            _personWindow.Show();
		}

		private void AddedNewPerson(object? sender, System.EventArgs e)
		{
			_domainManager.CreatePerson(_personWindow.NewPersonName, _personWindow.NewPersonEmail, _personWindow.NewPersonBirthDay);
            _personWindow.SavingNewPerson -= AddedNewPerson;
            _personWindow.Close();
			ShowUpdatedPeopleWindow();
        }

		private void ShowUpdatedPeopleWindow()
		{
            _peopleWindow.Show();
            _peopleWindow.People = _domainManager.GetAllPersons();
        }
	}
}