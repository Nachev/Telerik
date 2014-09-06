namespace RandomDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using RandomDataGenerator.Contracts;
    using RandomDataGenerator.Enumerations;

    public class RandomDataProvider
    {
        private const int ReasonableYearMaxValue = 9999;
        private const int ReasonableYearMinValue = 1990;

        private readonly string[] firstNames = new string[]
        {
            "Mohamed", "Youssef", "Ahmed", "Mahmoud", "Mustafa", "Yassin", "Taha", "Khaled", "Hamza", "Bilal", "Ibrahim", "Hassan", "Hussein", "Karim", "Tareq", "Abdel-Rahman", "Ali", "Omar", "Halim", "Murad", "Selim", "Abdallah", "Antonio", "Beau", "Beckett", "Brayden", "Bryce", "Caden", "Casey", "Cash", "Chase", "Clarke", "Dawson", "Declan", "Dominic", "Drew", "Elliot", "Elliott", "Ethan", "Ezra", "Gage", "Grayson", "Hayden", "Jaxson", "Jayden", "Kole", "Levi", "Logan", "Luke", "Matthew", "Morgan", "Nate", "Nolan", "Peter", "Ryker", "Sebastian", "Simon", "Tanner", "Taylor", "Theo", "Turner", "Ty", "Tye", "Jenna"
        };

        private readonly string[] lastNames = new string[]
        {
            "Martínez", "García", "Hernandez", "González", "López", "Rodríguez", "Pérez", "Sánchez", "Ramírez", "Flores", "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Wilson", "Anderson", "Taylor", "Thomas", "Moore", "Martin", "Jackson", "Thompson", "White", "Lee", "Harris", "Clark", "Lewis", "Robinson", "Walker", "Pérez", "Hall", "Young", "Allen", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson", "Hill", "Campbell", "Mitchell", "Roberts", "Carter", "Phillips", "Evans", "Turner", "Torres", "Parker", "Collins", "Jameson"
        };

        private readonly IDictionary<RandomDataType, string> seedData = new ReadOnlyDictionary<RandomDataType, string>(
            new Dictionary<RandomDataType, string>()
            {
                { RandomDataType.AllAlphaNumeric, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" },
                { RandomDataType.SmallLetters, "abcdefghijklmnopqrstuvwxyz" },
                { RandomDataType.BigLetters, "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
                { RandomDataType.Numerics, "1234567890" },
                { RandomDataType.LatinAlphabet, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" }
            });

        private readonly IRandomNumberProvider randomGenerator;

        public RandomDataProvider() : this(RandomNumberProvider.GetInstance())
        {
        }

        public RandomDataProvider(IRandomNumberProvider randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public string GetStringExact(int length, RandomDataType dataType = RandomDataType.LatinAlphabet)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = this.seedData[dataType][this.randomGenerator.GetIntInRange(0, this.seedData[dataType].Length - 1)];
            }

            return new string(result);
        }

        public string GetStringWithRandomLength(int minLength, int maxLength, RandomDataType dataType = RandomDataType.LatinAlphabet)
        {
            return this.GetStringExact(this.randomGenerator.GetIntInRange(minLength, maxLength), dataType);
        }

        public string GetFirstName()
        {
            var result = this.firstNames[this.randomGenerator.GetIntUpTo(this.firstNames.Length - 1)];
            return result;
        }

        public string GetLastName()
        {
            var result = this.lastNames[this.randomGenerator.GetIntUpTo(this.lastNames.Length - 1)];
            return result;
        }

        public DateTime GetDate(int minYear, int maxYear, int minMonth = 1, int maxMonth = 12, int minDay = 1, int maxDay = 30)
        {
            int randomYear = this.HandleYearValue(minYear, maxYear);
            int randomMonth = this.HandleMonthValue(minMonth, maxMonth);
            int randomDay = this.HandleDayValue(randomYear, randomMonth, minDay, maxDay);
            var result = new DateTime(randomYear, randomMonth, randomDay);
            return result;
        }
 
        public DateTime GetDate()
        {
            DateTime start = new DateTime(ReasonableYearMinValue, 1, 1);
            int range = (DateTime.Today - start).Days;
            int daysToAdd = this.randomGenerator.GetIntUpTo(range);
            var result = start.AddDays(daysToAdd);

            return result;
        }

        public DateTime GetDateTime(int year = 0, int month = 0, int day = 0)
        {
            if (year == 0)
            {
                year = this.randomGenerator.GetIntInRange(ReasonableYearMinValue, DateTime.Now.Year);
            }

            if (month == 0)
            {
                month = this.randomGenerator.GetIntInRange(1, 12);
            }

            if (day == 0)
            {
                day = this.HandleDayValue(year, month, 1, 12);
            }

            var hour = this.randomGenerator.GetIntInRange(0, 24);
            var minute = this.randomGenerator.GetIntInRange(0, 60);
            var seconds = this.randomGenerator.GetIntInRange(0, 60);

            DateTime result = new DateTime(year, month, day, hour, minute, seconds);          

            return result;
        }

        private int HandleDayValue(int randomYear, int randomMonth, int minDay, int maxDay)
        {
            int maxDaysInMonth = DateTime.DaysInMonth(randomYear, randomMonth);

            if (minDay < 1)
            {
                minDay = 1;
            }

            if (maxDay > maxDaysInMonth)
            {
                maxDay = maxDaysInMonth;
            }

            if (minDay > maxDaysInMonth)
            {
                minDay = maxDaysInMonth;
            }

            if (minDay < maxDay)
            {
                int swap = minDay;
                minDay = maxDay;
                maxDay = swap;
            }

            int randomDay = this.randomGenerator.GetIntInRange(1, maxDaysInMonth);
            return randomDay;
        }
 
        private int HandleMonthValue(int minMonth, int maxMonth)
        {
            if (minMonth < 1)
            {
                minMonth = 1;
            }

            if (maxMonth > 12)
            {
                maxMonth = 12;
            }

            if (minMonth > 12)
            {
                minMonth = 12;
            }

            if (minMonth > maxMonth)
            {
                int swap = minMonth;
                minMonth = maxMonth;
                maxMonth = swap;
            }

            int randomMonth = this.randomGenerator.GetIntInRange(minMonth, maxMonth);
            return randomMonth;
        }
 
        private int HandleYearValue(int minYear, int maxYear)
        {
            if (minYear < 0)
            {
                minYear = 0;
            }

            if (maxYear > ReasonableYearMaxValue)
            {
                maxYear = ReasonableYearMaxValue;
            }

            if (minYear > ReasonableYearMaxValue)
            {
                minYear = ReasonableYearMaxValue;
            }

            if (minYear > maxYear)
            {
                minYear = maxYear + minYear;
                maxYear = minYear - maxYear;
                minYear = minYear - maxYear;
            }

            int randomYear = this.randomGenerator.GetIntInRange(minYear, maxYear);
            return randomYear;
        }
    }
}