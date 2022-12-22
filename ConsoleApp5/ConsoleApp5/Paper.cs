using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Paper : INameAndCopy
    {
        private string name_paper;
        private Person author;
        private DateTime data_paper;

        public string Name_paper
        {
            get { return name_paper; }
            set { name_paper = value; }
        }

        public Person Name_author
        {
            get { return author; }
            set { author = value; }
        }

        public DateTime Data_paper
        {
            get { return data_paper; }
            set { data_paper = value; }
        }

        public Paper(string Name_paper, Person Name_author, DateTime Data_paper)
        {
            this.Name_paper = Name_paper;
            this.Name_author = Name_author;
            this.Data_paper = Data_paper;
        }

        public Paper()
        {
            this.Name_paper = " ";
            this.Name_author = new Person();
            this.Data_paper = new System.DateTime(0);
        }

        public override string ToString()
        {
            return name_paper + " " + author + " " + data_paper;
        }
        string INameAndCopy.Naming => this.name_paper;

        object INameAndCopy.DeepCopy()
        {
            return new Paper(this.name_paper, this.author, this.data_paper);
        }

    }

}
