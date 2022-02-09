using System;
using System.Collections.Generic;
using System.Text;

namespace LinqLibrary
{
    public class ListManager
    {
        public static List<Person> LoadSampleData()
        {
            List<Person> output = new List<Person>()
            {

                new Person{ FirstName = "Brett", LastName = "Beardall", Birthday = Convert.ToDateTime("11/01/1990"), YearsExperience = 15 },
                new Person{ FirstName = "Holly", LastName = "Beardall", Birthday = Convert.ToDateTime("11/01/1990"), YearsExperience = 5 },
                new Person{ FirstName = "Bob", LastName = "Builder", Birthday = Convert.ToDateTime("4/05/2009"), YearsExperience = 2 },
                new Person{ FirstName = "Christy", LastName = "Friar", Birthday = Convert.ToDateTime("02/14/2000"), YearsExperience = 20 },
                new Person{ FirstName = "Rick", LastName = "Astley", Birthday = Convert.ToDateTime("10/05/1965"), YearsExperience = 30 },
                new Person{ FirstName = "Ryan", LastName = "Unroe", Birthday = Convert.ToDateTime("01/01/2000"), YearsExperience = 1 }
            };

            return output;
        }

        public static List<int> LoadIntSampleData()
        {
            return new List<int>() { 15, 123, 78, -49, 55, 79, 2004, 23, -344, 500, 79, 220, 0 };
        }
    }
}