using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Translator : Person
{
    public string[] languages;

    public Translator(string firstName, string lastName, int age, string[] languages) : base(firstName, lastName, age)
    {
        this.languages = languages;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Языки: {string.Join(',', languages)}";
    }
}