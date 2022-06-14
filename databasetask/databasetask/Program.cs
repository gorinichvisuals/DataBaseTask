using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Program
    {
        static List<Person> people = new List<Person>();

        static int NumberInput(int minNumber, int maxNumber, string prompt)
        {
            Console.WriteLine(prompt);

            while (true)
            {
                bool correctInput = Int16.TryParse(Console.ReadLine(), out var number);
                if (!correctInput)
                {
                    Console.WriteLine("Не номер, попробуйте еще раз");
                    continue;
                }

                if (number < minNumber || number > maxNumber)
                {
                    Console.WriteLine("Номер не в диапазоне, повторите попытку");
                    continue;
                }

                return number;
            }
        }

        static string NoNumbersStringInput(string prompt)
        {
            Console.WriteLine(prompt);

            while (true)
            {
                string? input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("Пустой ввод, попробуйте еще раз");
                    continue;
                }

                if (!input.All(Char.IsLetter))
                {
                    Console.WriteLine("Ввод содержит цифры или другие неправильные символы, попробуйте еще раз");
                    continue;
                }

                return input;
            }
        }

        static string[] InputStringCommaArray(string prompt)
        {
            Console.WriteLine(prompt);

            while (true)
            {
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Пустой ввод, попробуйте еще раз");
                    continue;
                }

                string[] commaArray = input.Split(',');
                if (!commaArray.All(lang => lang.All(Char.IsLetter)))
                {
                    Console.WriteLine("Все значения должны содержать только буквы, попробуйте еще раз");
                    continue;
                }
                if (!commaArray.All(lang => lang.Length > 0))
                {
                    Console.WriteLine("Некоторое значение пустое, попробуйте еще раз");
                    continue;
                }

                return commaArray;
            }
        }

        static void PrintList()
        {
            if (people.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("База данных пуста");
                Console.ResetColor();

                return;
            }

            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }
        }
        static void FindHumanByName()
        {
            if (people.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("База данных пуста");
                Console.ResetColor();

                return;
            }

            SearchName();
        }

        static void InputBaseData(out string firstName, out string lastName, out int age)
        {
            Console.WriteLine();
            firstName = NoNumbersStringInput("Введите имя:");
            lastName = NoNumbersStringInput("Введите фамилию:");
            age = NumberInput(18, 65, "Введите возраст (минимальный 18 максимальный 65):");
        }
        static void SearchName()
        {

            Console.WriteLine();
            string searchName = NoNumbersStringInput("Введите имя для поиска: ");
            var peopleList = people.Where(x => x.firstName.Contains(searchName));

            if (peopleList.Count() > 0)
            {
                foreach (Person h in peopleList)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Найдено: ");
                    Console.ResetColor();
                    Console.Write(h);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Совпадений не обнаружено.");
            }
        }

        static Doctor CreateDoctor()
        {
            string firstName;
            string lastName;
            int age;

            InputBaseData(out firstName, out lastName, out age);
            string specialization = NoNumbersStringInput("Введите специализацию:");

            return new Doctor(firstName, lastName, age, specialization);
        }

        static Soldier CreateSoldier()
        {
            string firstName;
            string lastName;
            int age;

            InputBaseData(out firstName, out lastName, out age);
            string rank = NoNumbersStringInput("Введите ранг:");

            return new Soldier(firstName, lastName, age, rank);
        }

        static Translator CreateTranslator()
        {
            string firstName;
            string lastName;
            int age;

            InputBaseData(out firstName, out lastName, out age);
            string[] languages = InputStringCommaArray("Введите язык или несколько языков, разделенных запятой: ");

            return new Translator(firstName, lastName, age, languages);
        }

        static Person SelectPersonClass()
        {
            Console.WriteLine();
            int classSelection = NumberInput(1, 3, "Выберите класс человека: 1 - Доктор, 2 - Солдат, 3 - Переводчик:");

            switch (classSelection)
            {
                case 1:
                    return CreateDoctor();
                case 2:
                    return CreateSoldier();
                case 3:
                    return CreateTranslator();
                default:
                    throw new Exception("Невозможно.");
            }
        }

        static void AddPerson()
        {
            while (true)
            {
                Person p = SelectPersonClass();
                people.Add(p);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Добавлено: ");
                Console.ResetColor();
                Console.Write($"{p}");
                Console.WriteLine();
                Console.WriteLine();

                int inputAgain = NumberInput(1, 2, "Ввести другого человека? 1 - Да, 2 - Нет");

                if (inputAgain == 2)
                {
                    return;
                }
            }
        }

        static void RemovePerson()
        {
            if (people.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("База данных пуста");
                Console.ResetColor();

                return;
            }

            int index = NumberInput(1, people.Count, "Ввод индекса человека в базу данных:") - 1;
            Person p = people[index];
            people.RemoveAt(index);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Удалено: ");
            Console.ResetColor();
            Console.Write($"{p}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Вывести информацию по всем людям - 1");
                Console.WriteLine("Найти человека по имени - 2");
                Console.WriteLine("Добавить нового человека - 3");
                Console.WriteLine("Удалить человека - 4");
                Console.WriteLine("Выход - 5");
                Console.WriteLine();
                Console.Write("Введите цифру: ");

                bool numb = Int32.TryParse(Console.ReadLine(), out var number);

                switch (number)
                {
                    case 1:
                        PrintList();
                        break;
                    case 2:
                        FindHumanByName();
                        break;
                    case 3:
                        AddPerson();
                        break;
                    case 4:
                        RemovePerson();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Неправильное значение, попробуйте снова.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}