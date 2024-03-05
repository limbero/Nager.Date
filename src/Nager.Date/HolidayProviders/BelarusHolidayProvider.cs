using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Belarus HolidayProvider
    /// </summary>
    internal sealed class BelarusHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Belarus HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BelarusHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BY;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Новы год",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Новы год",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Orthodox Christmas Day",
                    LocalName = "Каляды праваслаўныя",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Мiжнародны жаночы дзень",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Дзень працы",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory Day",
                    LocalName = "Дзень Перамогi",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 3),
                    EnglishName = "Independence Day",
                    LocalName = "Дзень Незалежнасцi",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 7),
                    EnglishName = "October Revolution Day",
                    LocalName = "Дзень Кастрычніцкай рэвалюцыі",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Catholic Christmas Day",
                    LocalName = "Каляды каталiцкiя",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(9),
                    EnglishName = "Commemoration Day",
                    LocalName = "Радунiца",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);


            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Новы год", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 2, "Новы год", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 7, "Каляды праваслаўныя", "Orthodox Christmas Day", countryCode));
            //items.Add(new Holiday(year, 3, 8, "Мiжнародны жаночы дзень", "International Women's Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Дзень працы", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 9, "Дзень Перамогi", "Victory Day", countryCode));
            //items.Add(new Holiday(year, 7, 3, "Дзень Незалежнасцi", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 11, 7, "Дзень Кастрычніцкай рэвалюцыі", "October Revolution Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Каляды каталiцкiя", "Catholic Christmas Day", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(9), "Радунiца", "Commemoration Day", countryCode));
            
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belarus"
            };
        }
    }
}
