using Microsoft.Data.SqlClient;
using PersonsAssignment.Domain.Model;
using PersonsAssignment.Domain.Repository;
using System.Data.Common;

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

				SqlCommand cmd = new($"SELECT * FROM Personen WHERE Id = @id;", _connection);

				DbParameter idParameter = new SqlParameter("id", id);
				cmd.Parameters.Add(idParameter);

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
				SqlCommand command = new SqlCommand($"INSERT INTO Personen (Naam, Email, Geboortedatum) VALUES (@Naam, @Email, @BirthDay); SELECT CAST(scope_identity() AS int)", _connection);

				DbParameter nameParameter = new SqlParameter("Naam", person.Name);
				command.Parameters.Add(nameParameter);

				DbParameter emailParameter = new SqlParameter("Email", person.Email);
				command.Parameters.Add(emailParameter);

				DbParameter birthdayParameter = new SqlParameter("BirthDay", person.BirthDate);
				command.Parameters.Add(birthdayParameter);

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
			ExecuteQuery($"UPDATE Personen SET Naam = @Name, Email = @Email, Geboortedatum=@BirthDate WHERE id = @Id", new List<SqlParameter>
			{
				new SqlParameter("Name", person.Name),
				new SqlParameter("Email", person.Email),
				new SqlParameter("BirthDate", person.BirthDate),
				new SqlParameter("Id", person.Id),
			});
		}

		private int ExecuteQuery(string sql, List<SqlParameter> parameters)
		{
			try
			{
				_connection.Open();
				SqlCommand command = new SqlCommand(sql, _connection);
				parameters.ForEach(p => command.Parameters.Add(p));
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
			ExecuteQuery($"DELETE FROM Personen WHERE id = @Id;", new List<SqlParameter>()
			{
				new SqlParameter("Id",id)
			});
		}
	}
}