
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Person
    {
        private string name;
        private string second_name;
        private System.DateTime birth_date;

        public Person()
        {
            this.name = "";
            this.second_name = "";
            this.birth_date = new System.DateTime(0);
        }

        public Person(string name, string second_name, DateTime birth_date)
        {
            this.name = name;
            this.second_name = second_name;
            this.birth_date = birth_date;
        }

        public Person DeepCopy()
        {
            return new Person(this.name, this.second_name, this.birth_date);
        }

        public override int GetHashCode()
        {
            return (
                Shifter.ShiftAndWrap(this.birth_date.GetHashCode(), 4) ^
                Shifter.ShiftAndWrap(this.second_name.GetHashCode(), 2) ^
                this.name.GetHashCode()
            );
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Person))
                return false;
            Person person = (Person)obj;
            return (
                this.name.Equals(person.Name) &&
                this.second_name.Equals(person.SecondName) &&
                this.birth_date.Equals(person.Dr)
            );
        }

        public static bool operator ==(Person first, Person second)
        {
            return first.Name == second.Name && first.SecondName == second.SecondName && first.Dr == second.Dr;
        }

        public static bool operator !=(Person first, Person second)
        {
            return !(first == second);
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string SecondName
        {
            get { return this.second_name; }
            set { this.second_name = value; }
        }

        public DateTime Dr
        {
            get { return this.birth_date; }
            set { this.birth_date = value; }
        }

        public int DrInt
        {
            get { return (int)this.birth_date.Ticks; }
            set { this.birth_date = new DateTime(value); }
        }

        public override string ToString()
        {
            return "Name: " + this.name +
                " Second name: " + this.second_name +
                " birth date: " + this.birth_date.ToString();
        }

        public virtual string ToShortString()
        {
            return "Name: " + this.name + " Second name: " + this.second_name;
        }

    }
}
