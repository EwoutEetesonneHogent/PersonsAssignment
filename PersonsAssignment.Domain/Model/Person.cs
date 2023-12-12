namespace PersonsAssignment.Domain.Model
{
    public class Person
    {
		private readonly List<string> RequiredCharacters = new() { "@", "." };
		private string _email;
        public Person(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public Person(int id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email 
		{ 
			get => _email;
			set 
			{
				if(RequiredCharacters.Any(c=>!value.Contains(c)))
				{
					throw new ApplicationException("Email requires these characters to be present " + string.Join(" ", RequiredCharacters));
				}
				_email = value; 
			} 
		}
        public DateTime BirthDate { get; set; }

        public override string? ToString()
        {
            return $"[{Id}] {Name} - {Email} // {BirthDate.ToString("dd/MMM-yyyy")}";
        }
    }
}
