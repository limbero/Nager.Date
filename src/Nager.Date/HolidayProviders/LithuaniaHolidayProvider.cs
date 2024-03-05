using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Lithuania HolidayProvider
    /// </summary>
    internal sealed class LithuaniaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Lithuania HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LithuaniaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.LT;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Naujieji metai",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 16),
                    EnglishName = "The Day of Restoration of the State of Lithuania",
                    LocalName = "Lietuvos valstybės atkūrimo diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 11),
                    EnglishName = "Day of Restoration of Independence of Lithuania",
                    LocalName = "Lietuvos nepriklausomybės atkūrimo diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Working Day",
                    LocalName = "Tarptautinė darbo diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 24),
                    EnglishName = "St. John's Day",
                    LocalName = "Joninės, Rasos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 6),
                    EnglishName = "Statehood Day",
                    LocalName = "Valstybės diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Žolinė",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Visų šventųjų diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Souls' Day",
                    LocalName = "Vėlinės",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Šv. Kūčios",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Šv. Kalėdos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Šv. Kalėdos",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Velykos", year),
                this._catholicProvider.EasterMonday("Antroji Velykų diena", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Naujieji metai", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 16, "Lietuvos valstybės atkūrimo diena", "The Day of Restoration of the State of Lithuania", countryCode));
            //items.Add(new Holiday(year, 3, 11, "Lietuvos nepriklausomybės atkūrimo diena", "Day of Restoration of Independence of Lithuania", countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Velykos", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Antroji Velykų diena", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Tarptautinė darbo diena", "International Working Day", countryCode));
            //items.Add(new Holiday(year, 6, 24, "Joninės, Rasos", "St. John's Day", countryCode));
            //items.Add(new Holiday(year, 7, 6, "Valstybės diena", "Statehood Day", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Žolinė", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Visų šventųjų diena", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 11, 2, "Vėlinės", "All Souls' Day", countryCode, 2020));
            //items.Add(new Holiday(year, 12, 24, "Šv. Kūčios", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Šv. Kalėdos", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Šv. Kalėdos", "St. Stephen's Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Lithuania"
            };
        }
    }
}
