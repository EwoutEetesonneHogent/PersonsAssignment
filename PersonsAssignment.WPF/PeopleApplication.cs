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
			_peopleWindow.RemoveingPerson += RemovePerson;
			ShowUpdatedPeopleWindow();

        }

		private void AddingPerson(object? sender, System.EventArgs e)
		{
			_personWindow = new PersonWindow();
            _personWindow.SavingNewPerson += AddedNewPerson;
			_personWindow.ClosingPersonWindow += CanceledAddedNewPerson;
            _peopleWindow.Hide();
            _personWindow.Show();
		}

		private void AddedNewPerson(object? sender, System.EventArgs e)
		{
			_domainManager.CreatePerson(_personWindow.NewPersonName, _personWindow.NewPersonEmail, _personWindow.NewPersonBirthDay);
            _personWindow.SavingNewPerson -= AddedNewPerson;
            _personWindow.ClosingPersonWindow -= CanceledAddedNewPerson;
            _personWindow.Close();
			ShowUpdatedPeopleWindow();
        }

		private void CanceledAddedNewPerson(object? sender, System.EventArgs e)
		{
            ShowUpdatedPeopleWindow();
            _personWindow.SavingNewPerson -= AddedNewPerson;
            _personWindow.ClosingPersonWindow -= CanceledAddedNewPerson;
        }


        private void ShowUpdatedPeopleWindow()
		{
            _peopleWindow.Show();
            _peopleWindow.People = _domainManager.GetAllPersons();
        }

		private void RemovePerson(object? sender, Domain.Model.PersonToDeleteArgs e)
		{
			_domainManager.RemovePerson(e);
			ShowUpdatedPeopleWindow();
        }


	}
}