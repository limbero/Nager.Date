using Nager.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mongoli HolidayProvider
    /// </summary>
    internal class MongoliaHolidayProvider : IHolidayProvider
    {
        /// <summary>
        /// Mongolia HolidayProvider
        /// </summary>
        public MongoliaHolidayProvider()
        {
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MN;

            //TODO:Add lunar calendar support
            //TODO:Add Mongolian calendar support

            //Add Lunar New Year or Tsagaan Sar (Цагаан сар (Tsagaan sar))
            //Add Genghis Khan's birthday (Чингис хааны төрсөн өдөр (Chingis Khaany törsön ödör))

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Шинэ жил (Shine jil)", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 3, 8, "Олон Улсын Эмэгтэйчүүдийн Баяр", "International Women's Day", countryCode));
            items.Add(new Holiday(year, 6, 1, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new Holiday(year, 7, 11, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new Holiday(year, 7, 12, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new Holiday(year, 7, 13, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new Holiday(year, 7, 14, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new Holiday(year, 7, 15, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new Holiday(year, 11, 26, "Улс тунхагласны өдөр", "Republic Day", countryCode));
            items.Add(new Holiday(year, 12, 29, "Тусгаар Тогтнолын Өдөр ", "Independence Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mongolia"
            };
        }
    }
}