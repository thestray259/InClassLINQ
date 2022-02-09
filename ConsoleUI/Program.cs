using System;
using System.Collections.Generic;
using LinqLibrary;
using System.Linq; 

namespace ConsoleUI
{
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item); 
            }
        }

        public static void PrintPeople(this IEnumerable<Person> peopleList)
        {
            foreach (var person in peopleList)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}" +
                    $"({person.Birthday.ToShortDateString()}): " +
                    $"Experience: {person.YearsExperience} years");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // LINQ = Language Integrated Query
            var numberList = ListManager.LoadIntSampleData();
            List<Person> peopleList = ListManager.LoadSampleData();
            //GetEvens(numberList); 
            //ListPeopleName(peopleList); 
            //GetMaxNumber(numberList); 
            //OrderByTest(peopleList); 
            GroupByLastName(peopleList); 
        }

        private static void ListPeopleName(List<Person> personList)
        {
            var result = personList.Select(p => p.FullName).ToList();
            result.Print(); 
        }

        private static void OrderByTest(List<Person> personList)
        {
            personList = personList.OrderBy(person => person.LastName).ToList();
            personList.PrintPeople(); 
        }

        private static void GetMaxNumber(List<int> items)
        {
            int largestNumber = items.Max();
            Console.WriteLine($"Largest Number: {largestNumber}"); 
        }

        private static void GetEvens(List<int> numberList)
        {
            var evenNumbers = new List<int>(); 
/*            foreach (var item in numberList)
            {
                if (item % 2 == 0) evenNumbers.Add(item); 
            }
*/
            // Query Syntax - less common 
/*            evenNumbers = (from number in numberList
                           where number % 2 == 0
                           select number).ToList();*/

            // Extention Syntax
            evenNumbers = numberList.Where(number => number % 2 == 0).ToList(); 

            evenNumbers.Print(); 
        }

        public static void GroupByLastName(List<Person> personList)
        {
            //Key: Smith 
            //      [Aaron Smith, 
            //      Roger Smith] 

            //var lastNameGroups = personList.GroupBy(person => person.LastName); // displays everyone by last name
            var lastNameGroups = personList.GroupBy(person => person.LastName).OrderBy(p => p.Key).Take(2); // displays the top 2 last names 

            foreach (IGrouping<string, Person> lastNameGroup in lastNameGroups)
            {
                Console.WriteLine($"Lastname: {lastNameGroup.Key} ({lastNameGroup.Count()})");

                foreach (Person person in lastNameGroup)
                {
                    Console.WriteLine($"\t{person.FullName}"); 
                }

                Console.WriteLine(); 
            }
        }
    }
}
