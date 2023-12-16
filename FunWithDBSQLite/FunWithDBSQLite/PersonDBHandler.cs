using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;


namespace FunWithDBSQLite
{
    public sealed class PersonDBHandler
    {

        
       
        static readonly string ConString =
            ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        static readonly PersonDBHandler instance = new PersonDBHandler();




        private PersonDBHandler() {
            CreateTable();

            //seed the table
            Person newP1 = new Person
            {
                FirstName = "Han",
                LastName = "Solo",
                Title = "Jedi",
                City = "Cornellia",
                Age = 40,
                PhoneNumber = "514-343-658",
                Address = "900 Rue Riverside, Saint-Lambert, QC J4P 3P2",
                Languages = "French, Spanish, English",
                Email = "john.doe@example.com",
                Education = "Bachelor of Arts in Galactic Studies, University of Coruscant (UC) - Graduated in 20 BBY"
            };

            Person newP2 = new Person
            {
                FirstName = "Lea",
                LastName = "Organa",
                Title = "Testing",
                City = "Aideraan",
                Age = 20,
                PhoneNumber = "514-343-658",
                Address = "900 Rue Riverside, Saint-Lambert, QC J4P 3P2",
                Languages = "French, Spanish, English",
                Email = "john.doe@example.com",
                Education = "Bachelor of Arts in Galactic Studies, University of Coruscant (UC) - Graduated in 20 BBY"
            };

            Person newP3 = new Person
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                Title = "Jedi",
                City = "Tatooine",
                Age = 20,
                PhoneNumber = "514-343-658",
                Address = "900 Rue Riverside, Saint-Lambert, QC J4P 3P2",
                Languages = "French, Spanish, English",
                Email = "john.doe@example.com",
                Education = "Bachelor of Arts in Galactic Studies, University of Coruscant (UC) - Graduated in 20 BBY"
            };

            Person newP4 = new Person
            {
                FirstName = "Anakin",
                LastName = "Skywalker",
                Title = "Dark Side",
                City = "Tatooine",
                Age = 40,
                PhoneNumber = "514-343-658",
                Address = "900 Rue Riverside, Saint-Lambert, QC J4P 3P2",
                Languages = "French, Spanish, English",
                Email = "john.doe@example.com",
                Education = "Bachelor of Arts in Galactic Studies, University of Coruscant (UC) - Graduated in 20 BBY"
            };

            AddPerson(newP1);
            AddPerson(newP2);
            AddPerson(newP3);
            AddPerson(newP4);
        }

        public static PersonDBHandler Instance

        {
            get { return instance; }
        }


        public void CreateTable () 
        {
            using (SQLiteConnection con = new SQLiteConnection(ConString)) 
            {
            
                con.Open ();
                string drop = "drop table if exists Persons;";
                SQLiteCommand command1 = new SQLiteCommand (drop, con);
                command1.ExecuteNonQuery ();

                string table = "create table Persons (ID integer primary key, FirstName text, LastName text, Title text, City text, Age integer, PhoneNumber text, Address text, Languages text, Email text, Education text);";
                SQLiteCommand command2 = new SQLiteCommand (table, con);
                command2.ExecuteNonQuery ();
            
            }
        
        }

        public int AddPerson(Person person) {

            int newId = 0;
            int rows = 0;

            using (SQLiteConnection con = new SQLiteConnection
                (ConString)) 
            {

                con.Open();

                //create parameterized query
                string query = "INSERT INTO Persons (FirstName, LastName, Title, City, Age, PhoneNumber, Address, Languages, Email, Education) VALUES (@FirstName, @LastName, @Title, @City, @Age, @PhoneNumber, @Address, @Languages, @Email, @Education)";

                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                //Pass values to the query parameters
                insertcom.Parameters.AddWithValue("@FirstName", person.FirstName);
                insertcom.Parameters.AddWithValue("@LastName", person.LastName);
                insertcom.Parameters.AddWithValue("@Title", person.Title);
                insertcom.Parameters.AddWithValue("@City", person.City);
                insertcom.Parameters.AddWithValue("@Age", person.Age);
                insertcom.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                insertcom.Parameters.AddWithValue("@Address", person.Address);
                insertcom.Parameters.AddWithValue("@Languages", person.Languages);
                insertcom.Parameters.AddWithValue("@Email", person.Email);
                insertcom.Parameters.AddWithValue("@Education", person.Education);


                try
                {

                    rows = insertcom.ExecuteNonQuery();
                    //lets get the rowid inserted
                    insertcom.CommandText = "select last_insert_rowid()";
                    Int64 LastRowID64 = Convert.ToInt64(insertcom.ExecuteScalar
                     ());
                    //Then grab the bottom 32-bits as the unique id of the row
                    newId = Convert.ToInt32(LastRowID64);
                }

                catch (SQLiteException e) {

                    Console.WriteLine("Error Generated. Details: " + e.ToString
                        ());
                }
                return newId;
            }



        }

        public Person GetPerson(int id) 
        { 

            Person person = new Person();

            using (SQLiteConnection con = new SQLiteConnection(ConString))
            {

                con.Open();

                SQLiteCommand getcom = new SQLiteCommand("Select * from Persons WHERE Id = @Id", con);

                getcom.Parameters.AddWithValue("@Id", id);

                using (SQLiteDataReader reader = getcom.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        if (Int32.TryParse(reader["Id"].ToString(), out int id2))
                        {
                            person.Id = id2;
                        }

                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.Title = reader["Title"].ToString();
                        person.City = reader["City"].ToString();

                        if (Int32.TryParse(reader["Age"].ToString(), out int age))
                        {
                            person.Age = age;
                        }

                        person.PhoneNumber = reader["PhoneNumber"].ToString();
                        person.Address = reader["Address"].ToString();
                        person.Languages = reader["Languages"].ToString();
                        person.Email = reader["Email"].ToString();
                        person.Education = reader["Education"].ToString();

                        
                    }

                }

                return person;

            }
        }


        public int UpdatePerson(Person person) 
        {

            int row = 0;

            using (SQLiteConnection con = new SQLiteConnection(ConString))
            {
                

                con.Open();

                string query = "UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, Title = @Title, City = @City, Age = @Age, PhoneNumber = @PhoneNumber, Address = @Address, Languages = @Languages, Email = @Email, Education = @Education WHERE Id = @Id";

                SQLiteCommand updatecom = new SQLiteCommand(@query, con);
                updatecom.Parameters.AddWithValue("@Id", person.Id);
                updatecom.Parameters.AddWithValue("@FirstName", person.FirstName);
                updatecom.Parameters.AddWithValue("@LastName", person.LastName);
                updatecom.Parameters.AddWithValue("@Title", person.Title);
                updatecom.Parameters.AddWithValue("City", person.City);
                updatecom.Parameters.AddWithValue("@Age", person.Age);
                updatecom.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                updatecom.Parameters.AddWithValue("@Address", person.Address);
                updatecom.Parameters.AddWithValue("@Languages", person.Languages);
                updatecom.Parameters.AddWithValue("@Email", person.Email);
                updatecom.Parameters.AddWithValue("@Education", person.Education);


                try
                {
                    row = updatecom.ExecuteNonQuery();
                }

                catch (SQLiteException e) {

                    Console.WriteLine("Error Generated. Details " + e.ToString());
                }
            }
            return row;
            }

        public int DeletePerson(Person person) {

            int row = 0;

            using (SQLiteConnection con = new SQLiteConnection
               (ConString))
            {

                con.Open();

                string query = "DELETE FROM Persons WHERE id = @Id";
                SQLiteCommand deletecom = new SQLiteCommand(@query, con);
                deletecom.Parameters.AddWithValue("@Id", person.Id);

                try
                {
                    row = deletecom.ExecuteNonQuery();

                }
                catch (SQLiteException e)
                {

                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }

                return row;

            }

        }

        public List<Person> ReadAllPersons()
        {

            List<Person> listPersons = new List<Person>();

            using (SQLiteConnection con = new SQLiteConnection
               (ConString))
            {

                con.Open();
                SQLiteCommand com = new SQLiteCommand("Select * from Persons", con);

                using (SQLiteDataReader reader = com.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        //Create a Person object
                        Person person = new Person();

                        if (Int32.TryParse(reader["Id"].ToString(), out int id))
                        {
                            person.Id = id;
                        }

                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.Title = reader["Title"].ToString();
                        person.City = reader["City"].ToString();

                        if (Int32.TryParse(reader["Age"].ToString(), out int age))
                        {
                            person.Age = age;
                        }
                        person.PhoneNumber = reader["PhoneNumber"].ToString();
                        person.Address = reader["Address"].ToString();
                        person.Languages = reader["Languages"].ToString();
                        person.Email = reader["Email"].ToString();
                        person.Education = reader["Education"].ToString();

                        listPersons.Add(person);
                    }
                }
            }
            return listPersons;

        }
    }
}
