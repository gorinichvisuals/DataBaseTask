using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class Person
{
    public string firstName;
    public string lastName;
    public int age;

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public override string ToString()
    {
        return $"Имя: {firstName} Фамилия: {lastName} Возраст: {age}";
    }
}