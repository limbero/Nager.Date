using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Serbia HolidayProvider
    /// </summary>
    internal class SerbiaHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Serbia HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public SerbiaHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.RS;

            var newYearsDay1 = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var newYearsDay2 = new DateTime(year, 1, 2).Shift(saturday => saturday, sunday => sunday.AddDays(1), monday => monday.AddDays(1));

            var statehoodDay1 = new DateTime(year, 2, 15).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var statehoodDay2 = new DateTime(year, 2, 16).Shift(saturday => saturday, sunday => sunday.AddDays(1), monday => monday.AddDays(1));

            var labourDay1 = new DateTime(year, 5, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var labourDay2 = new DateTime(year, 5, 2).Shift(saturday => saturday, sunday => sunday.AddDays(1), monday => monday.AddDays(1));

            var items = new List<Holiday>();
            items.Add(new Holiday(newYearsDay1, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new Holiday(newYearsDay2, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 7, "Božić", "Christmas Day", countryCode));
            items.Add(new Holiday(statehoodDay1, "Dan državnosti Srbije", "Statehood Day", countryCode));
            items.Add(new Holiday(statehoodDay2, "Dan državnosti Srbije", "Statehood Day", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Veliki petak", year, countryCode));
            items.Add(this._orthodoxProvider.EasterSunday("Vaskrs (Uskrs)", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Vaskrsni (Uskrsni) ponedeljak", year, countryCode));
            items.Add(new Holiday(labourDay1, "Praznik rada", "Labour Day", countryCode));
            items.Add(new Holiday(labourDay2, "Praznik rada", "Labour Day", countryCode));
            items.Add(new Holiday(year, 11, 11, "Dan primirja", "Armistice Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Serbia"
            };
        }
    }
}