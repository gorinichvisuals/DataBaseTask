using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Doctor : Person
{
    public string specialization;

    public Doctor(string firstName, string lastName, int age, string specialization) : base(firstName, lastName, age)
    {
        this.specialization = specialization;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Специализация: {specialization}";
    }
}