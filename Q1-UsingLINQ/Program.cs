using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q1Lab3;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #3 - Using LINQ
/// ** Date (MM/dd/yyy) : 03/12/2020
/// </summary>
namespace Q1_UsingLINQ
{
    class Program
    {
        // ** Main
        static void Main(string[] args)
        {
            CountriesInAlphabeticalOrder();
            CountriesInDescendingOrderOfNumberOfResources();
            NamesOfTheCountriesThatSharesABorderWithArgentina();
            NamesOfTheCountriesThatHasMoreThan10000000Population();
            ListTheCountryWithHighestPopulation();
            ListAllTheReligionInSouthAmericaInDictionaryOrder();
            Console.ReadKey();
        }

        // ** 1.1 List Countries in Alphabetical Order
        private static void CountriesInAlphabeticalOrder()
        {
            int i = 1;
            //// ** For Question 1.1
            Console.WriteLine(">> 1.1 List the names of the countries in alphabetical order");
            //foreach (Country c in Country.GetCountries()
            //    .OrderBy(n => n.Name))
            //{
            //    Console.WriteLine($"   {i++}. {c.Name}");
            //}

            i = 1;
            var _orderedList = from c in Country.GetCountries()
                               orderby c.Name
                               select c;
            foreach (Country c in _orderedList)
            {
                Console.WriteLine($"   {i++}. {c.Name}");
            }
            Console.WriteLine();
        }

        // ** 1.2 Countries in descending order of number of resources
        private static void CountriesInDescendingOrderOfNumberOfResources()
        {
            int i = 1;
            //// ** For Question 1.2
            Console.WriteLine(">> 1.2 List the names of the countries in descending order of number of resources");
            //var _descendingOrderList = Country.GetCountries()
            //    .OrderByDescending(n => n.Resources.Count);
            //foreach (Country c in _descendingOrderList)
            //{
            //    Console.WriteLine($"   {i++}. {c.Name} - {c.Resources.Count}");
            //}

            i = 1;
            var _descendingOrderList = from c in Country.GetCountries()
                                       orderby c.Resources.Count descending
                                       select c;
            foreach (Country c in _descendingOrderList)
            {
                Console.WriteLine($"   {i++}. {c.Name} - {c.Resources.Count}");
            }
            Console.WriteLine();
        }

        // ** 1.3 Name of the countries that shares a border with Argentina
        private static void NamesOfTheCountriesThatSharesABorderWithArgentina()
        {
            int i = 1;
            // ** For Question 1.3
            Console.WriteLine(">> 1.3 List the names of the countries that shares a border with Argentina");
            //foreach (Country c in Country.GetCountries()
            //    .Where(n => n.Name == "Argentina"))
            //{
            //    foreach (string b in c.Borders)
            //    {
            //        Console.WriteLine($"   {i++}. {b}");
            //    }
            //}

            i = 1;
            var _border = from c in Country.GetCountries()
                          where c.Name == "Argentina"
                          select c;
            foreach (Country c in _border)
            {
                Console.WriteLine($"   {c.Name}");
                foreach (string b in c.Borders)
                {
                    Console.WriteLine($"   {i++}. {b}");
                }
            }
            Console.WriteLine();
        }

        // ** 1.4 Name of the countries that has more than 10,000,000 population
        private static void NamesOfTheCountriesThatHasMoreThan10000000Population()
        {
            int i = 1;
            // ** For Question 1.4
            Console.WriteLine(">> 1.4 List the names of the countries that has more than 10,000,000 population");
            //foreach (Country c in Country.GetCountries()
            //    .Where(n => n.Population > 10000000))
            //{
            //    Console.WriteLine($"   {i++}. {c.Name}");
            //}

            i = 1;
            var _population = from c in Country.GetCountries()
                              where c.Population > 10000000
                              select c;
            foreach (Country c in _population)
            {
                Console.WriteLine($"   {i++}. {c.Name} - {c.Population.ToString("#,###")}");
            }
            Console.WriteLine();
        }

        // ** 1.5 List the country with highest population
        private static void ListTheCountryWithHighestPopulation()
        {
            int i = 1;
            // ** For Question 1.5
            Console.WriteLine(">> 1.5 List the country with highest population");
            //int _max1 = Country.GetCountries().Max(n => n.Population);
            //foreach (Country c in Country.GetCountries()
            //    .Where(n => n.Population == _max1))
            //{
            //    Console.WriteLine($"   {i++}. {c.Name}");
            //}

            i = 1;
            int _max2 = Country.GetCountries().Max(n => n.Population);
            var _maxPopulation = from c in Country.GetCountries()
                                 where c.Population == _max2
                                 select c;
            foreach (Country c in _maxPopulation)
            {
                Console.WriteLine($"   {i++}. {c.Name} - {c.Population.ToString("#,###")}");
            }
            Console.WriteLine();
        }

        // ** 1.6 List all the religion in South America in dictionary order
        private static void ListAllTheReligionInSouthAmericaInDictionaryOrder()
        {
            Dictionary<Country, string> _dictionary = new Dictionary<Country, string>();

            int i = 1;
            // ** For Question 1.6
            Console.WriteLine(">> 1.6 List all the religion in south America in dictionary order");
            var _orderedList = from c in Country.GetCountries()
                               orderby c.Name
                               select c;
            foreach (Country c in _orderedList)
            {
                _dictionary.Add(c, c.Name);
            }

            var _myList = _dictionary.Keys.ToList();
            foreach (Country c in _myList)
            {
                Console.WriteLine($"   {i++}. {c.Name}");
                Console.WriteLine($"          > Religions:");
                int x = 1;
                foreach (string r in c.Religions)
                {
                    Console.WriteLine($"          {x++}. {r}");
                }
            }
        }

    }
}
