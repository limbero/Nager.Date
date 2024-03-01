using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Netherlands HolidayProvider
    /// </summary>
    internal class NetherlandsHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Netherlands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NetherlandsHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.NL;

            #region King's Day is Sunday fallback

            var kingsDay = 27;
            var kingsDate = new DateTime(year, 4, kingsDay);
            if (kingsDate.DayOfWeek == DayOfWeek.Sunday)
            {
                kingsDay = 26;
            }

            #endregion

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Nieuwjaarsdag", "New Year's Day", countryCode, 1967));
            items.Add(this._catholicProvider.GoodFriday("Goede Vrijdag", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Eerste Paasdag", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Tweede Paasdag", year, countryCode).SetLaunchYear(1642));
            items.Add(new Holiday(year, 4, kingsDay, "Koningsdag", "King's Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Hemelvaartsdag", year, countryCode));
            items.Add(this._catholicProvider.Pentecost("Eerste Pinksterdag", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Tweede Pinksterdag", year, countryCode));
            items.Add(new Holiday(year, 12, 25, "Eerste Kerstdag", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Tweede Kerstdag", "St. Stephen's Day", countryCode));

            #region Liberation Day

            var liberationDay = new Holiday(year, 5, 5, "Bevrijdingsdag", "Liberation Day", countryCode, 1945);

            if (year >= 1990)
            {
                //in 1990, the day was declared to be a national holiday
                items.Add(liberationDay.SetType(HolidayTypes.Authorities | HolidayTypes.School));
            }
            else if (year >= 1945)
            {
                if (year % 5 == 0)
                {
                    items.Add(liberationDay);
                }
            }

            #endregion

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Netherlands"
            };
        }
    }
}