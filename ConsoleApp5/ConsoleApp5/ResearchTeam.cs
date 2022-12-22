using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class ResearchTeam : Team, INameAndCopy
    {
        private string TemaIss;
        private TimeFrame Last;
        protected ArrayList User;
        protected ArrayList Publ;
        private Paper[] spisok;


        public ResearchTeam(
            string name,
            TimeFrame Last,
            int nom
        ) : base(name, nom)
        {
            this.Last = Last;
            this.Publ = new ArrayList();
            User = new ArrayList();
        }
        public ResearchTeam() : base()
        {
            this.Last = TimeFrame.Year;
            this.Publ = new ArrayList();
            User = new ArrayList();
        }

        public string temaIss
        {
            get { return temaIss; }
            set { temaIss = value; }
        }
        public string organ
        {
            get { return this.organ; }
            set { this.organ = value; }
        }

        public int nomer
        {
            get { return this.nomer; }
            set { this.nomer = value; }
        }

        public TimeFrame last
        {
            get { return this.Last; }
            set { this.Last = value; }
        }

        public Paper[] Spisok1
        {
            get { return spisok; }
        }

        public ArrayList Paper
        {
            get { return this.Publ; }
            set { this.Publ = value; }
        }
    
    public Team Team
        {
            get { return new Team(name, nom); }
            set
            {
                this.name = value.Name;
                this.nom = value.Nomer;
            }
        }
        public bool CheckTimeFrame(TimeFrame value)
        {
            return value == this.Last;
        }

        public void AddPapers(Object[] new_papers)
        {
            this.Paper.AddRange(new_papers);
        }
        public void AddMambers(Object[] new_users)
        {
            this.User.AddRange(new_users);
        }
        public new ResearchTeam DeepCopy()
        {
            ResearchTeam research = new ResearchTeam(this.name, this.Last, this.nom);
            research.AddPapers(this.Publ.ToArray().Select(a => ((INameAndCopy)a).DeepCopy()).ToArray());
            research.AddMambers(this.User.ToArray().Select(a => ((Person)a).DeepCopy()).ToArray());
            return research;
        }
        object INameAndCopy.DeepCopy()
        {
            ResearchTeam research = new ResearchTeam(this.name, this.Last, this.nom);
            research.AddPapers(this.Publ.ToArray().Select(a => ((INameAndCopy)a).DeepCopy()).ToArray());
            research.AddMambers(this.User.ToArray().Select(a => ((Person)a).DeepCopy()).ToArray());
            return research;
        }
        string INameAndCopy.Naming => this.name;

        
        public IEnumerable<Paper> GetResearchTeamWithNaming(DateTime time)
        {
            foreach (Paper Publ in this.Publ)
            {
                if (Publ.Data_paper > time)
                    yield return Publ;
            }
        }
        public IEnumerable<Paper> GetResearchTeamsWithStr(string str)
        {
            foreach (Paper Publ in this.Publ)
            {
                if (Publ.Name_paper.Contains(str))
                    yield return Publ;
            }
        }
        public IEnumerable<Paper> GetArticlesWithAuthorIsEditor()
        {
            foreach (Paper Publ in this.Publ)
                if (this.User.Contains(Publ.Name_author))
                    yield return Publ;
        }

        public IEnumerable<Person> GetEditorIsNotAuthors()
        {
            foreach (Person person in this.User)
                foreach (Paper article in this.Publ)
                    if (article.Name_author == person)
                        yield return person;
        }
        public override string ToString()
        {
            string res = (
                "Name: " + this.name +
                " Last: " + this.Last.ToString() +
                " Nomer: " + this.nom.ToString() +
                "\nPapers:\n"
            );
            if (this.Publ.Count == 0)
                res += "No publ";
            else
                foreach (Paper Publ in this.Publ)
                {
                    res += Publ.ToString() + '\n';
                }
            res += "Editors:\n";
            if (this.User.Count == 0)
                res += "No users";
            else
                foreach (Person mambers in this.User)
                {
                    res += mambers.ToString() + '\n';
                }
            return res;
        }

        public virtual string ToShortString()
        {
            return "Name: " + this.name +
                    " Last: " + this.Last.ToString() +
                    " Nomer: " + this.nom.ToString();
        }
        class ResearchTeamEnumerator : IEnumerator
        {
            public List<Paper> people;
            private int position = -1;

            public ResearchTeamEnumerator(ArrayList User, ArrayList Publ)
            {
                this.people = new List<Paper>();
                foreach (Paper publ in Publ)
                {
                    if (!User.Contains(publ.Name_author))
                        this.people.Add(publ);
                }
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return people[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < people.Count);
            }

            public void Reset()
            {
                position = -1;
            }
        } 

    }
}
