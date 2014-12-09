namespace _05.HashedSetImplementation
{
    using System;

    class HashedSetImplementationTest
    {
        static void Main(string[] args)
        {
            MyHashedSet<string> aspNetStudents = new MyHashedSet<string>();
            aspNetStudents.Add("S. Jobs");
            aspNetStudents.Add("B. Gates");
            aspNetStudents.Add("M. Dell");
            MyHashedSet<string> silverlightStudents = new MyHashedSet<string>();
            silverlightStudents.Add("M. Zuckerberg");
            silverlightStudents.Add("M. Dell");
            MyHashedSet<string> allStudents = new MyHashedSet<string>();
            allStudents.UnionWith(aspNetStudents);
            allStudents.UnionWith(silverlightStudents);
            MyHashedSet<string> intersectStudents = new MyHashedSet<string>(aspNetStudents);
            intersectStudents.IntersectWith(silverlightStudents);
            Console.WriteLine("ASP.NET students: " + string.Join(", ", aspNetStudents));
            Console.WriteLine("Silverlight students: " + string.Join(", ", silverlightStudents));
            Console.WriteLine("All students: " + string.Join(", ", allStudents));
            Console.WriteLine("Students in both ASP.NET and Silverlight: " + string.Join(", ", intersectStudents));
        }
    }
}
