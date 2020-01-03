using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    enum EyeColor { blue, grey, green, brown, mixed }
    enum HairColor { blonde, grey, brown }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public EyeColor EyeCol { get; set; }
        public HairColor HairCol { get; set; }
        public int Height { get; set; }

        public Person(string firstName, string lastName, DateTime birthDate, EyeColor eyeCol, HairColor hairCol, int height)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            EyeCol = eyeCol;
            HairCol = hairCol;
            Height = height;
        }
    }
}
