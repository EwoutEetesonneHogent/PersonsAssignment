namespace PersonsAssignment.Domain
{
    public class Person
    {
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
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public string BirthDateDatabaseString { get => BirthDate.ToString("yyyy-MM-dd HH:mm:ss"); }

        public override string? ToString()
        {
            return $"[{Id}] {Name} - {Email} // {BirthDate.ToString("dd/MMM-yyyy")}";
        }
    }
}
