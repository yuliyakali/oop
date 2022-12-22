using System;


namespace OOP1
{
    internal class Person
    {
        private string name;
        private string surname;
        private System.DateTime birth_day;

        public Person()
        {
            this.name = "";
            this.surname = "";
            this.birth_day = new System.DateTime(0);
        }
        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birth_day = birthday;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Birthday
        {
            get { return birth_day; }
            set { birth_day = value; }
        }
        public int IntDR
        {
            get { return (int)this.birth_day.Ticks; }
            set { this.birth_day = new DateTime(value); }

        }
        public override string ToString()
        {
            return name + " " + surname + " " + birth_day;
        }
        public virtual string ToShortString()
        {
            return name + " " + surname;
        }

        internal class Paper
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
        }
        enum TimeFrame { Year, TwoYears, Long };
        class ResearchTeam
        {
            private string TemaIss;
            private string Organ;
            private int NomerReg;
            private TimeFrame Last;
            private Paper[] spisok;

            public ResearchTeam(string temaIss, string organ, int nomer, TimeFrame Last)
            {
                TemaIss = temaIss;
                Organ = organ;
                NomerReg = nomer;

            }
            public ResearchTeam()
            {
                this.temaIss = "";
                this.organ = "";
                this.nomer = 0;
                //this last = TimeFrame.Year;
                this.spisok = new Paper[0];
            }

            public string temaIss
            {
                get { return TemaIss; }
                set { TemaIss = value; }
            }
            public string organ
            {
                get { return this.Organ; }
                set { this.Organ = value; }
            }

            public int nomer
            {
                get { return this.NomerReg; }
                set { this.NomerReg = value; }
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

            public bool CheckTimeFrame(TimeFrame value)
            {
                return value == this.Last;
            }

            public void AddPapers(Paper[] spisok, params Paper[] papers)
            {
                
                Array.Resize(ref spisok, spisok.Length + papers.Length);
                for (int i = 0; i < papers.Length; ++i)
                {
                    spisok[spisok.Length + i] = papers[i];
                }
            }

            public override string ToString()
            {
                return TemaIss + " " + Organ + " " + NomerReg + " " + Last + " " + spisok;
            }

            public virtual string ToShortString()
            {
                return TemaIss + " " + Organ + " " + NomerReg + " " + Last;
            }


        }

        static void Main()
        {
            ResearchTeam team = new ResearchTeam(
                "So Fun Music",
                "Gum",
                16,
                TimeFrame.TwoYears);

            Console.WriteLine(team.ToShortString());

            Console.WriteLine(
                TimeFrame.Year.ToString() + ' ' +
                TimeFrame.TwoYears.ToString() + ' ' +
                TimeFrame.Long.ToString() + "\n\n" +
                team.ToShortString() + "\n\n" +
                team.ToString() + '\n'
            );

            team.AddPapers(
                new Paper[1] {
                    new Paper (
                        "FCT",
                        new Person("Sasha", "Bondar", new System.DateTime(2003, 7, 12)),
                        new System.DateTime(2022, 7, 25)
                    )
                }
            );
            Console.WriteLine(team.ToString() + '\n');

            int rows, columns;
            Console.Write("Enter 2 numbers (use . or , to separate numbers): ");
            string[] input = Console.ReadLine().Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            rows = Int32.Parse(input[0]);
            columns = Int32.Parse(input[1]);


            Paper[] first = new Paper[rows * columns];
            for (int i = 0; i < rows * columns; ++i)
                first[i] = new Paper();
            long start = Environment.TickCount;
            for (int i = 0; i < rows * columns; ++i)
                first[i].Data_paper = new System.DateTime(2003, 7, 24);
            Console.WriteLine("first mil. sec: " + (Environment.TickCount - start).ToString());

            Paper[,] second = new Paper[rows, columns];
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < columns; ++j)
                    second[i, j] = new Paper();
            start = Environment.TickCount;
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < columns; ++j)
                    second[i, j].Data_paper = new System.DateTime(2003, 7, 24);
            Console.WriteLine("second mil. sec: " + (Environment.TickCount - start).ToString());

            int c = 1, count = rows * columns;
            while (count > c)
            {
                count -= c;
                c++;
            }
            Paper[][] third = new Paper[c][];
            for (int i = 0; i < c - 1; ++i)
            {
                third[i] = new Paper[i + 1];
            }
            third[c - 1] = new Paper[count];
            for (int i = 0; i < third.Length; ++i)
                for (int j = 0; j < third[i].Length; ++j)
                    third[i][j] = new Paper();
            start = Environment.TickCount;
            for (int i = 0; i < third.Length; ++i)
                for (int j = 0; j < third[i].Length; ++j)
                    third[i][j].Data_paper = new System.DateTime(2003, 7, 24);
            Console.WriteLine("third mil. sec: " + (Environment.TickCount - start).ToString());
            Console.ReadLine();
        }
    }

}