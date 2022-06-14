using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Soldier : Person
{
    public string rank;

    public Soldier(string firstName, string lastName, int age, string rank) : base(firstName, lastName, age)
    {
        this.rank = rank;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Ранг военного: {rank}";
    }
}