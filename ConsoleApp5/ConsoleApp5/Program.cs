using ConsoleApp5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface INameAndCopy
    {
        string Naming { get; }
        object DeepCopy();
    }
    enum TimeFrame { Year, TwoYears, Long };

    public static class Shifter
    {
        public static int ShiftAndWrap(int value, int positions)
        {
            positions &= 0x1F;
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

    }


    static class Program
    {
        static void Main()
        {
            PrintPoint(1);
            Team team = new Team();
            Team team1 = new Team();
            Console.WriteLine(
                "Data equals: " + (team == team1).ToString() +
                " Reference equals: " + ReferenceEquals(team, team1).ToString() +
                "\nFirst hash: " + team.GetHashCode().ToString() +
                " Second hash: " + team1.GetHashCode().ToString()
            );
            PrintPoint(2);
            try
            {
                team.Nomer = -2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            PrintPoint(3);
            ResearchTeam m = new ResearchTeam();
            m.AddPapers(
                new Paper[1] {
                    new Paper (
                        "TFklk",
                        new Person("Sasha", "Bondar", new System.DateTime(2003, 7, 12)),
                        new System.DateTime(2022, 7, 25)
                    )                    
                }
            );
            m.AddMambers(
                new Person[2] {
                    new Person("Kate", "Borovskay", new System.DateTime(2003, 3, 16)),
                    new Person("Sony", "Kopteva", new System.DateTime(2003, 9, 30))
                }
            );
            Console.WriteLine(m.ToString());
            PrintPoint(4);
            Console.WriteLine(m.Team.ToString());
            PrintPoint(5);
            ResearchTeam m1 = m.DeepCopy();
            ((Paper)m1.Paper[0]).Name_paper = "Changed";
            m1.AddMambers(
                new Person[1] {
                    new Person("Nicolay", "Nepovinsh", new System.DateTime(2003, 06, 24))
                }
            );
            m1.Nomer = 10;
            Console.WriteLine(m.ToString());
            Console.WriteLine(m1.ToString());
            PrintPoint(6);
            foreach (Paper Publ in m1.GetResearchTeamWithNaming(new System.DateTime(2003, 3, 16)))
                Console.WriteLine(Publ.ToString());
            PrintPoint(7);
            foreach (Paper Publ in m1.GetResearchTeamsWithStr("борьба"))
                Console.WriteLine(Publ.ToString());
            PrintPoint(8);
            foreach (Paper Publ in m1.GetResearchTeamsWithStr("нерв"))
                Console.WriteLine(Publ.ToString());
            PrintPoint(9);
            foreach (Paper Publ in m1.GetArticlesWithAuthorIsEditor())
                Console.WriteLine(Publ.ToString());
            PrintPoint(10);
            foreach (Person person in m1.GetEditorIsNotAuthors())
                Console.WriteLine(person.ToString());
            Console.ReadKey();
        }
        static void PrintPoint(int point)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------\nPoint " + point.ToString() + '\n');
        }
    }
}
