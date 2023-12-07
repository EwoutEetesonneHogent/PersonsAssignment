namespace PersonsAssignment.WPF
{
	internal class PeopleApplication
	{
		private readonly PeopleMapper _peopleMapper;
		public PeopleApplication()
		{
			_peopleMapper = new PeopleMapper();
		}

		private enum Action
		{
			GetAll,
			GetOne,
			Create,
			Update,
			Delete,
			Count
		}

		public void Run()
		{
			while (true)
			{
				try
				{
					switch (AskPickAction())
					{
						case Action.GetAll:
							GetAll();
							break;
						case Action.GetOne:
							GetOne();
							break;
						case Action.Create:
							Create();
							break;
						case Action.Update:
							Update();
							break;
						case Action.Delete:
							Delete();
							break;
						case Action.Count:
							Count();
							break;
						default:
							break;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
				Console.WriteLine();
			}
		}

		private Action AskPickAction()
		{
			Console.WriteLine("Please pick an action");
			foreach (Action action in Enum.GetValues(typeof(Action)).Cast<Action>())
			{
				Console.WriteLine($"[{(int)action}] {action}");
			}
			return (Action)int.Parse(Console.ReadLine());
		}

		private void GetAll()
		{
			Console.WriteLine(string.Join("\n", _peopleMapper.GetAllPeople()));
		}

		private void GetOne()
		{
			Console.WriteLine(_peopleMapper.GetPersonById(AskForId()));
		}

		private void Create()
		{
			string name = AskForStringInput("Please enter person name");
			string email = AskForStringInput("Please enter person email");
			DateTime dateTime = AskForDateInput("Please enter person birthdate");

			Person person = new(name, email, dateTime);
			Console.WriteLine("Created person with id " + _peopleMapper.CreatePerson(person));
		}

		private void Update()
		{
			Person personToUpdate = _peopleMapper.GetPersonById(AskForId());
			personToUpdate.Name = AskForStringInput($"Please provide new value for name (currently: {personToUpdate.Name}):");
			personToUpdate.Email = AskForStringInput($"Please provide new value for email (currently: {personToUpdate.Email}):");
			personToUpdate.BirthDate = AskForDateInput($"Please provide new value for date (currently: {personToUpdate.BirthDate}):");

			_peopleMapper.UpdatePerson(personToUpdate);
			Console.WriteLine("Updated person to " + personToUpdate.ToString());
		}

		private void Delete()
		{
			int id = AskForId();
			_peopleMapper.DeletePerson(id);
			Console.WriteLine($"Deleted person with id {id}");
		}

		private void Count()
		{
			Console.WriteLine($"Database currently contains {_peopleMapper.CountPeople()} person(s)");
		}

		private int AskForId()
		{
			Console.WriteLine("Please enter id");
			return int.Parse(Console.ReadLine());
		}

		private string AskForStringInput(string text)
		{
			Console.WriteLine(text);
			return Console.ReadLine();
		}

		private DateTime AskForDateInput(string text)
		{
			Console.WriteLine(text);
			return DateTime.Parse(Console.ReadLine());
		}
	}
}
