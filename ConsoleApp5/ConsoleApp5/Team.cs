using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Team : INameAndCopy
    {
        protected string name;
        protected int nom;

        public Team()
        {
            this.name = "";
            this.nom = 0;
        }
        public Team(string name, int nom)
        {
            this.name = name;
            this.nom = nom;
        }

        public virtual Team DeepCopy()
        {
            return new Team(this.name, this.nom);
        }
        public override string ToString()
        {
            return (
                "Team name: " + this.name +
                " nomer: " + this.nom.ToString()
            );
        }
        public override int GetHashCode()
        {
            return (
                Shifter.ShiftAndWrap(this.nom.GetHashCode(), 4) ^
                this.name.GetHashCode()
            );
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Team))
                return false;
            Team team = (Team)obj;
            return (
                this.name.Equals(team.name) &&
                this.nom.Equals(team.nom)
            );
        }

        public static bool operator ==(Team team1, Team team2)
        {
            return (
                team1.Nomer == team2.Nomer &&
                team1.Name == team2.Name
           );
        }

        public static bool operator !=(Team team1, Team team2)
        {
            return !(team1 == team2);
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Nomer
        {
            get { return this.nom; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value >= 0");
                this.nom = value;
            }
        }
        string INameAndCopy.Naming => this.name;
        object INameAndCopy.DeepCopy()
        {
            return new Team(this.name, this.nom);
        }

    }
}
