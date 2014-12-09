namespace _06.PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneEntry
    {
        string firstName;
        string town;
        string phoneNumber;

        public PhoneEntry(string firstName, string town, string phoneNumber)
            : this(firstName, town, phoneNumber, null, null)
        {
        }

        public PhoneEntry(string firstName, string town, string phoneNumber, string lastName)
            : this(firstName, town, phoneNumber, lastName, null)
        {
        }

        public PhoneEntry(string firstName, string town, string phoneNumber, string lastName, string middleName)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0} ", this.FirstName);
            if (!string.IsNullOrEmpty(this.MiddleName))
            {
                result.AppendFormat("{0} ", this.MiddleName);
            }

            if (!string.IsNullOrEmpty(this.LastName))
            {
                result.AppendFormat("{0} ", this.LastName);
            }

            result.AppendFormat("{0} ", this.Town);
            result.AppendFormat("{0} ", this.PhoneNumber);

            return result.ToString();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FirstName", "FirstName cannot be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Town
        {
            get
            {
                return this.town;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town", "Town cannot be null or empty.");
                }

                this.town = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("PhoneNumber", "PhoneNumber cannot be null or empty.");
                }

                this.phoneNumber = value;
            }
        }
    }
}
