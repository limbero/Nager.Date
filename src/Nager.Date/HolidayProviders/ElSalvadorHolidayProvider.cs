using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// El Salvador HolidayProvider
    /// </summary>
    internal class ElSalvadorHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// El Salvador HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ElSalvadorHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SV;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            //TODO: Add Holy Week / Easter bad documentation on wikipedia

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labor Day",
                    LocalName = "Día del trabajo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 3),
                    EnglishName = "The Day of the Cross",
                    LocalName = "Día de la Cru",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 7),
                    EnglishName = "Soldiers' Day",
                    LocalName = "Día del Soldado",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 10),
                    EnglishName = "Mother's Day",
                    LocalName = "Día de las Madres",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 10),
                    EnglishName = "Father's Day",
                    LocalName = "Día del Padre",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 1),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas de agosto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 2),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas de agosto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 3),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas de agosto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 4),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas de agosto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 5),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas de agosto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 6),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas de agosto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 7),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas de agosto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 15),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "Children's Day",
                    LocalName = "Día del niño",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Ethnic Pride Day",
                    LocalName = "Día de la raza",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "Day of the Dead",
                    LocalName = "El día de los difuntos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 7),
                    EnglishName = "National Pupusa Festival",
                    LocalName = "Festival Nacional De La Pupusa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 8),
                    EnglishName = "National Pupusa Festival",
                    LocalName = "Festival Nacional De La Pupusa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 9),
                    EnglishName = "National Pupusa Festival",
                    LocalName = "Festival Nacional De La Pupusa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 10),
                    EnglishName = "National Pupusa Festival",
                    LocalName = "Festival Nacional De La Pupusa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "National Pupusa Festival",
                    LocalName = "Festival Nacional De La Pupusa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 12),
                    EnglishName = "National Pupusa Festival",
                    LocalName = "Festival Nacional De La Pupusa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 13),
                    EnglishName = "National Pupusa Festival",
                    LocalName = "Festival Nacional De La Pupusa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 21),
                    EnglishName = "Day of the Queen of Peace",
                    LocalName = "Dia de la Reina de la Paz",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Noche Buena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Fin de año",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 5, 1, "Día del trabajo", "Labor Day", countryCode));
            //items.Add(new Holiday(year, 5, 3, "Día de la Cru", "The Day of the Cross", countryCode));
            //items.Add(new Holiday(year, 5, 7, "Día del Soldado", "Soldiers' Day", countryCode));
            //items.Add(new Holiday(year, 5, 10, "Día de las Madres", "Mother's Day", countryCode));
            //items.Add(new Holiday(year, 5, 10, "Día del Padre", "Father's Day", countryCode));
            //items.Add(new Holiday(year, 8, 1, "Fiestas de agosto", "August Festivals", countryCode));
            //items.Add(new Holiday(year, 8, 2, "Fiestas de agosto", "August Festivals", countryCode));
            //items.Add(new Holiday(year, 8, 3, "Fiestas de agosto", "August Festivals", countryCode));
            //items.Add(new Holiday(year, 8, 4, "Fiestas de agosto", "August Festivals", countryCode));
            //items.Add(new Holiday(year, 8, 5, "Fiestas de agosto", "August Festivals", countryCode));
            //items.Add(new Holiday(year, 8, 6, "Fiestas de agosto", "August Festivals", countryCode));
            //items.Add(new Holiday(year, 8, 7, "Fiestas de agosto", "August Festivals", countryCode));
            //items.Add(new Holiday(year, 9, 15, "Día de la Independencia", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 10, 1, "Día del niño", "Children's Day", countryCode));
            //items.Add(new Holiday(year, 10, 12, "Día de la raza", "Ethnic Pride Day", countryCode));
            //items.Add(new Holiday(year, 11, 2, "El día de los difuntos", "Day of the Dead", countryCode));
            //items.Add(new Holiday(year, 11, 7, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            //items.Add(new Holiday(year, 11, 8, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            //items.Add(new Holiday(year, 11, 9, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            //items.Add(new Holiday(year, 11, 10, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            //items.Add(new Holiday(year, 11, 11, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            //items.Add(new Holiday(year, 11, 12, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            //items.Add(new Holiday(year, 11, 13, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            //items.Add(new Holiday(year, 11, 21, "Dia de la Reina de la Paz", "Day of the Queen of Peace", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Noche Buena", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Fin de año", "New Year's Eve", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/El_Salvador#Public_holidays",
            };
        }
    }
}
