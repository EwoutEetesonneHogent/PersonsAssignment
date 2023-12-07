using Microsoft.Data.SqlClient;
using PersonsAssignment.Domain.Model;
using PersonsAssignment.Domain.Repository;

namespace PersonsAssignment.Database
{
	public class PeopleMapper : IPersonsRepository
	{
		private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Personen;Integrated Security=True;Encrypt=False";
		private SqlConnection _connection;

		public PeopleMapper()
		{
			_connection = new SqlConnection(ConnectionString);
		}

		public List<Person> GetAllPeople()
		{
			List<Person> result = new();
			try
			{
				_connection.Open();

				SqlCommand cmd = new("SELECT * FROM Personen;", _connection);
				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						int id = (int)reader["Id"];
						string name = (string)reader["Naam"];
						string email = (string)reader["Email"];
						DateTime date = (DateTime)reader["Geboortedatum"];

						result.Add(new Person(id, name, email, date));
					}
				}

				return result;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				_connection.Close();
			}
		}

		public Person GetPersonById(int id)
		{
			try
			{
				_connection.Open();

				SqlCommand cmd = new($"SELECT * FROM Personen WHERE Id = '{id}';", _connection);
				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						int personId = (int)reader["Id"];
						string name = (string)reader["Naam"];
						string email = (string)reader["Email"];
						DateTime date = (DateTime)reader["Geboortedatum"];

						return new Person(personId, name, email, date);
					}
				}

				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				_connection.Close();
			}
		}

		public int CreatePerson(Person person)
		{
			try
			{
				_connection.Open();
				SqlCommand command = new SqlCommand($"INSERT INTO Personen (Naam, Email, Geboortedatum) VALUES ('{person.Name}', '{person.Email}', '{person.BirthDateDatabaseString}'); SELECT CAST(scope_identity() AS int)", _connection);

				return (int)command.ExecuteScalar();
			}
			catch (Exception ex)
			{
				throw;
			}
			finally
			{
				_connection.Close();
			}
		}

		public void UpdatePerson(Person person)
		{
			ExecuteQuery($"UPDATE Personen SET Naam = '{person.Name}', Email = '{person.Email}', Geboortedatum='{person.BirthDateDatabaseString}' WHERE id = '{person.Id}'");
		}

		private int ExecuteQuery(string sql)
		{
			try
			{
				_connection.Open();
				SqlCommand command = new SqlCommand(sql, _connection);
				return command.ExecuteNonQuery();
				throw new Exception("Something went wrong with person update");

			}
			catch (Exception ex)
			{
				return -1;
			}
			finally
			{
				_connection.Close();
			}
		}

		public int CountPeople()
		{
			try
			{
				_connection.Open();

				SqlCommand command = new("SELECT COUNT(*) FROM Personen;", _connection);
				int count = (int)command.ExecuteScalar();

				return count;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				_connection.Close();
			}


		}

		public void DeletePerson(int id)
		{
			ExecuteQuery($"DELETE FROM Personen WHERE id = '{id}';");
		}
	}
}