using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithDBSQLite
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PersonDBHandler personDB = PersonDBHandler.Instance;
            //Create Table
            personDB.CreateTable();
            Console.WriteLine("Create the Persons table\n");

            
            //Insert a Person
            Console.WriteLine("Insert a row into Persons Table\n");
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

            int IdP1 = personDB.AddPerson(newP1);
            Console.WriteLine("Person with Id: {0} added", IdP1);

            //Get Person by Id
            Console.WriteLine("Get a row in the Persons table by row id\n");
            Person retP1 = personDB.GetPerson(IdP1);
            Console.WriteLine(retP1.ToString());

            
            //Update Example
            Console.WriteLine("\nUpdate a row in the Persons table\n");
            retP1.FirstName = "Han 2";
            int numRows = personDB.UpdatePerson(retP1);
            Console.WriteLine("NumRows: " + numRows);
            Person retP1Updated = personDB.GetPerson(retP1.Id);
            Console.WriteLine(retP1Updated.ToString());

            //Delete Example
            Console.WriteLine("\nDelete a row in the Persons Table\n");
            int numRowsDeleted = personDB.DeletePerson(retP1Updated);
            Console.WriteLine(numRowsDeleted + " row(s) deleted");

            //Add more people
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

            int IdP2 = personDB.AddPerson(newP2);

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

            int IdP3 = personDB.AddPerson(newP3);

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

            int IdP4 = personDB.AddPerson(newP4);

            //Get All Persons from the Table
            Console.WriteLine("\nRead all rows in the persons table\n");
            List<Person> personList = personDB.ReadAllPersons();
            foreach (Person person in personList) 
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
