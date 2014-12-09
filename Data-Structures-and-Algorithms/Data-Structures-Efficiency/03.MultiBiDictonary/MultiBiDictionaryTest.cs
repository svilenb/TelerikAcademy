namespace _03.MultiBiDictonary
{
    using System;
    using System.Linq;

    public class MultiBiDictionaryTest
    {
        public static void Main()
        {
            var students = new MultiBiDictonary<string, string, int>(true);
            students.Add("Ivan", "Ivanov", 3);
            students.Add("Ivan", "Petrov", 2);
            students.Add("Ivan", "Hristov", 3);
            students.Add("Petar", "Ivanov", 4);
            students.Add("Petar", "Hristov", 4);
            students.Add("Petar", "Tzolov", 5);
            students.Add("Hristo", "Ivanov", 5);
            students.Add("Hristo", "Petrov", 3);
            students.Add("Petar", "Ivanov", 6);

            var searchName = "Ivanov";
            Console.WriteLine("Average grade of {0}:", searchName);
            Console.WriteLine((double)students.FindSecondKey(searchName).Sum() / students.FindSecondKey(searchName).Count);

            searchName = "Petar";
            Console.WriteLine("Average grade of {0}:", searchName);
            Console.WriteLine((double)students.FindFirstKey(searchName).Sum() / students.FindFirstKey(searchName).Count);

            searchName = "Petar";
            var searchFamilyName = "Ivanov";
            Console.WriteLine("Average grade of {0} {1}:", searchName, searchFamilyName);
            Console.WriteLine((double)students.FindBothKeys(searchName, searchFamilyName).Sum() / students.FindBothKeys(searchName, searchFamilyName).Count);
        }
    }
}
