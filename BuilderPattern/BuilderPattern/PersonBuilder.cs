using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    class PersonBuilder
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private EyeColor eyeCol;
        private HairColor hairCol;
        private int height;

        public PersonBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            firstName = "John";
            lastName = "Doe";
            birthDate = new DateTime(1900, 1, 1);
            eyeCol = EyeColor.blue;
            hairCol = HairColor.brown;
            height = 180;
        }

        public Person Build()
        {
            Person person = new Person(this.firstName, this.lastName, this.birthDate, this.eyeCol, this.hairCol, this.height);
            return person;
        }

        public PersonBuilder WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public PersonBuilder WithBirthDate(DateTime birthDate)
        {
            this.birthDate = birthDate;
            return this;
        }

        public PersonBuilder WithEyeColor(EyeColor eyeCol)
        {
            this.eyeCol = eyeCol;
            return this;
        }

        public PersonBuilder WithHairColor(HairColor hairCol)
        {
            this.hairCol = hairCol;
            return this;
        }

        public PersonBuilder WithHeight(int height)
        {
            this.height = height;
            return this;
        }
    }
}
