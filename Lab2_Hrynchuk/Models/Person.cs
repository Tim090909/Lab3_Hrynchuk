using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2_Hrynchuk.Models
{
    internal class Person
    {
        private string _lastName;
        private string _firstName;
        private string _email;
        private DateTime _birthDate;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string EmailAddress
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public Person(string firstName, string lastName, string emailAddress, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            BirthDate = birthDate;
        }

        public Person(string firstName, string lastName, string emailAddress)
            : this(firstName, lastName, emailAddress, DateTime.Today) { }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName, string.Empty, birthDate) { }

        public bool IsAdult => CalcPersonAge(BirthDate) >= 18;
        public string SunSign => CalcWesternZodiacSign(BirthDate);
        public string ChineseSign => CalcChineseZodiacSign(BirthDate);
        public bool IsBirthday => IsTodayBirthday(BirthDate);

        public int CalcPersonAge(DateTime userBDate)
        {
            int userAge;
            DateTime currentDate = DateTime.Now;
            userAge = currentDate.Year - userBDate.Year;
            if (currentDate.Month < userBDate.Month || (currentDate.Month == userBDate.Month && currentDate.Day < userBDate.Day))
            {
                userAge--;
            }
            return userAge;
        }

        private bool IsTodayBirthday(DateTime userBDate)
        {
            DateTime currentDate = DateTime.Now;
            if (userBDate.Day == currentDate.Day && userBDate.Month == currentDate.Month) { return true; }
            return false;
        }

        private string CalcWesternZodiacSign(DateTime userBDate)
        {
            int userDayOfBirth = userBDate.Day;
            int userMonthOfBirth = userBDate.Month;

            switch (userMonthOfBirth)
            {
                case 1:
                    return (userDayOfBirth >= 20) ? "Aquarius" : "Capricorn";
                case 2:
                    return (userDayOfBirth >= 19) ? "Pisces" : "Aquarius";
                case 3:
                    return (userDayOfBirth >= 21) ? "Aries" : "Pisces";
                case 4:
                    return (userDayOfBirth >= 20) ? "Taurus" : "Aries";
                case 5:
                    return (userDayOfBirth >= 21) ? "Gemini" : "Taurus";
                case 6:
                    return (userDayOfBirth >= 21) ? "Cancer" : "Gemini";
                case 7:
                    return (userDayOfBirth >= 23) ? "Leo" : "Cancer";
                case 8:
                    return (userDayOfBirth >= 23) ? "Virgo" : "Leo";
                case 9:
                    return (userDayOfBirth >= 23) ? "Libra" : "Virgo";
                case 10:
                    return (userDayOfBirth >= 23) ? "Scorpio" : "Libra";
                case 11:
                    return (userDayOfBirth >= 22) ? "Sagittarius" : "Scorpio";
                case 12:
                    return (userDayOfBirth >= 22) ? "Capricorn" : "Sagittarius";
                default:
                    return "Unknown";
            }
        }


        //Chinese new year begins almost randomly from 21 Jan to 21 Feb so if the user have DoB on this part of year i just return two possible zodiacs
        private string CalcChineseZodiacSign(DateTime userBDate)
        {
            int userDayOfBirth = userBDate.Day;
            int userMonthOfBirth = userBDate.Month;
            int userYearOfBirth = userBDate.Year % 12;

            switch (userYearOfBirth)
            {
                case 0:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Goat" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Goat or Monkey" : "Monkey";
                case 1:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Monkey" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Monkey or Rooster" : "Rooster";
                case 2:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Rooster" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Rooster or Dog" : "Dog";
                case 3:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Dog" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Dog or Pig" : "Pig";
                case 4:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Pig" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Pig or Rat" : "Rat";
                case 5:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Rat" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Rat or Ox" : "Ox";
                case 6:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Ox" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Ox or Tiger" : "Tiger";
                case 7:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Tiger" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Tiger or Rabbit" : "Rabbit";
                case 8:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Rabbit" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Rabbit or Dragon" : "Dragon";
                case 9:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Dragon" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Dragon or Snake" : "Snake";
                case 10:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Snake" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Snake or Horse" : "Horse";
                case 11:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Horse" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Horse or Goat" : "Goat";
                default:
                    return "Unknown";
            }
        }
    }
}
