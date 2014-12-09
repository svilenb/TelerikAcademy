namespace _06.PhoneBook
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class PhoneBook
    {
        MultiDictionary<string, PhoneEntry> firstNames;
        MultiDictionary<string, PhoneEntry> middleNames;
        MultiDictionary<string, PhoneEntry> lastNames;
        MultiDictionary<string, PhoneEntry> towns;

        public PhoneBook(List<PhoneEntry> entries)
        {
            firstNames = new MultiDictionary<string, PhoneEntry>(true);
            middleNames = new MultiDictionary<string, PhoneEntry>(true);
            lastNames = new MultiDictionary<string, PhoneEntry>(true);
            towns = new MultiDictionary<string, PhoneEntry>(true);

            foreach (var entry in entries)
            {
                firstNames.Add(entry.FirstName, entry);
                firstNames.Add(entry.MiddleName, entry);
                firstNames.Add(entry.LastName, entry);
                firstNames.Add(entry.Town, entry);
            }
        }

        public List<PhoneEntry> Find(string name)
        {
            List<PhoneEntry> foundEntries = new List<PhoneEntry>();

            foundEntries.AddRange(firstNames[name]);
            foundEntries.AddRange(middleNames[name]);
            foundEntries.AddRange(lastNames[name]);

            return foundEntries;
        }

        public List<PhoneEntry> Find(string name, string town)
        {
            List<PhoneEntry> foundEntries = new List<PhoneEntry>();

            ICollection<PhoneEntry> entry = firstNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            entry = middleNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            entry = lastNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            return foundEntries;
        }
    }
}
