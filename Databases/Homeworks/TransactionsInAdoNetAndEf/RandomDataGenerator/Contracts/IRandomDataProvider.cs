namespace RandomDataGenerator.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using RandomDataGenerator.Contracts;
    using RandomDataGenerator.Enumerations;

    public interface IRandomDataProvider
    {
        string GetStringExact(int length, RandomDataType dataType = RandomDataType.LatinAlphabet);

        string GetStringWithRandomLength(int minLength, int maxLength, RandomDataType dataType = RandomDataType.LatinAlphabet);

        string GetFirstName();

        string GetLastName();

        DateTime GetDate(int minYear, int maxYear, int minMonth = 1, int maxMonth = 12, int minDay = 1, int maxDay = 30);

        DateTime GetDate();

        DateTime GetDateTime(int year = 0, int month = 0, int day = 0);
    }
}