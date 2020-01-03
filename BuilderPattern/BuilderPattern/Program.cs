using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // no builder
            Person person1 = new Person("Michal", "Wojtas", new DateTime(1985, 7, 10), EyeColor.grey, HairColor.brown, 170);
            Console.WriteLine("Hello {0} {1}, your eye color is {2} and your hair color is {3}",person1.FirstName,person1.LastName,person1.EyeCol.ToString(), person1.HairCol.ToString());

            Person person2 = new Person("Gosia", "Kowalska", new DateTime(1982, 11, 1), EyeColor.blue, HairColor.blonde, 165);
            Console.WriteLine("Hello {0} {1}, your eye color is {2} and your hair color is {3}", person2.FirstName, person2.LastName, person2.EyeCol.ToString(), person2.HairCol.ToString());

            // with builder
            PersonBuilder personBuilder = new PersonBuilder();
            Person person3 = personBuilder.WithFirstName("Waldek").WithLastName("Fajoski").Build();

            Console.WriteLine("Hello man created with Builder pattern - {0} {1}, your eye color is {2} and your hair color is {3}", person3.FirstName, person3.LastName, person3.EyeCol.ToString(), person3.HairCol.ToString());
            Console.ReadLine();
        }
    }
}
