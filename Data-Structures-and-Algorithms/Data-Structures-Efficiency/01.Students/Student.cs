namespace _01.Students
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            if (this.LastName != other.LastName)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            else
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
