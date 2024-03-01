using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Slovakia HolidayProvider
    /// </summary>
    internal class SlovakiaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Slovakia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SlovakiaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SK;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Deň vzniku Slovenskej republiky", "Day of the Establishment of the Slovak Republic", countryCode));
            items.Add(new Holiday(year, 1, 6, "Zjavenie Pána", "Epiphany", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Veľkonočný piatok", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Veľkonočný pondelok", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Sviatok práce", "International Workers' Day", countryCode));
            items.Add(new Holiday(year, 5, 8, "Deň víťazstva nad fašizmom", "Day of victory over fascism", countryCode));
            items.Add(new Holiday(year, 7, 5, "Sviatok svätého Cyrila a svätého Metoda", "St. Cyril and Methodius Day", countryCode));
            items.Add(new Holiday(year, 8, 29, "Výročie Slovenského národného povstania", "Slovak National Uprising anniversary", countryCode));
            items.Add(new Holiday(year, 9, 1, "Deň Ústavy Slovenskej republiky", "Day of the Constitution of the Slovak Republic", countryCode));
            items.Add(new Holiday(year, 9, 15, "Sedembolestná Panna Mária", "Day of Our Lady of the Seven Sorrows", countryCode));
            items.Add(new Holiday(year, 11, 1, "Sviatok Všetkých svätých", "All Saints’ Day", countryCode));
            items.Add(new Holiday(year, 11, 17, "Deň boja za slobodu a demokraciu", "Struggle for Freedom and Democracy Day", countryCode));
            items.Add(new Holiday(year, 12, 24, "Štedrý deň", "Christmas Eve", countryCode));
            items.Add(new Holiday(year, 12, 25, "Prvý sviatok vianočný", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Druhý sviatok vianočný", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Slovakia"
            };
        }
    }
}