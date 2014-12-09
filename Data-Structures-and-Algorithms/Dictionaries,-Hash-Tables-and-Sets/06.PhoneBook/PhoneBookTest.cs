namespace _06.PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    class PhoneBookTest
    {
        static void Main(string[] args)
        {
            List<PhoneEntry> phoneEntries = GetPhones();
            PhoneBook phoneBook = new PhoneBook(phoneEntries);

            List<string> commands = GetCommands();
            ExecuteCommands(commands, phoneBook);
        }

        private static List<PhoneEntry> GetPhones()
        {
            List<PhoneEntry> phoneEntries = new List<PhoneEntry>();
            using (StreamReader reader = new StreamReader(@"..\..\phones.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] entryData = line.Split('|');

                    string[] names = entryData[0].Trim().Split();

                    var phoneEntry = CreateEntry(entryData, names);
                    phoneEntries.Add(phoneEntry);
                    line = reader.ReadLine();
                }
            }

            return phoneEntries;
        }

        private static PhoneEntry CreateEntry(string[] entryData, string[] names)
        {
            PhoneEntry phoneEntry;
            if (names.Length == 3)
            {
                phoneEntry =
                   new PhoneEntry(names[0].Trim(), entryData[1].Trim(), entryData[2].Trim(), names[2].Trim(), names[1].Trim());
            }
            else if (names.Length == 2)
            {
                phoneEntry =
                    new PhoneEntry(names[0].Trim(), entryData[1].Trim(), entryData[2].Trim(), names[1].Trim());
            }
            else
            {
                phoneEntry =
                    new PhoneEntry(names[0].Trim(), entryData[1].Trim(), entryData[2].Trim());
            }

            return phoneEntry;
        }

        private static List<string> GetCommands()
        {
            List<string> commands = new List<string>();

            using (StreamReader reader = new StreamReader("..\\..\\commands.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var matches = Regex.Matches(line, @"""([^""]*"")");
                    if (matches.Count == 1)
                    {
                        var match = matches[0].ToString();
                        commands.Add(match.Substring(1, match.Length - 2));
                    }
                    else if (matches.Count == 2)
                    {
                        var match1 = matches[0].ToString();
                        var match2 = matches[1].ToString();
                        commands.Add(match1.Substring(1, match1.Length - 2) + " " + match2.Substring(1, match2.Length - 2));
                    }

                    line = reader.ReadLine();
                }
            }

            return commands;
        }

        private static void ExecuteCommands(List<string> commands, PhoneBook phoneBook)
        {
            foreach (var command in commands)
            {
                List<PhoneEntry> found = new List<PhoneEntry>();
                string[] arguments = command.Split();
                if (arguments.Length == 1)
                {
                    found = phoneBook.Find(arguments[0]);
                }
                else if (arguments.Length == 2)
                {
                    found = phoneBook.Find(arguments[0], arguments[1]);
                }

                PrintFoundEntries(found, command);
            }
        }

        private static void PrintFoundEntries(List<PhoneEntry> found, string command)
        {
            Console.WriteLine("Command: {0}", command);
            foreach (var item in found)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
        }
    }
}
