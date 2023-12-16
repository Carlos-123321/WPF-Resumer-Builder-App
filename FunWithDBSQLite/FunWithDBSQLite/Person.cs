using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithDBSQLite
{
    public class Person
    {

        public int Id { get; set; }
      
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Languages { get; set; }

        public string Email { get; set; }

        public string Education { get; set; }
        

        public override string ToString()
        {
            string formatted = String.Format("{0}\t  {1}\t {2}\t {3}\t| {4} \t " +
                "{5}" + "{6}" + "{7}" + "{8}" + "{9}", Id, FirstName, LastName, Title, City, Age, PhoneNumber, Address, Languages, Email, Education);
            return formatted;
        }


    }
}
