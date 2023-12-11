using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUsersSQLite
{
     public class Person
    {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string City { get; set; }

            public int Age { get; set; }


            public override string ToString()
            {
                string formatted = String.Format("{0}\t  {1}\t {2}\t| {3} \t " +
                    "{4}", Id, FirstName, LastName, City, Age);
                return formatted;
            }


        }
    }



