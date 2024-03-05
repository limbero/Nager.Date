using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Vatican City HolidayProvider
    /// </summary>
    internal sealed class VaticanCityHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// VaticanCity HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public VaticanCityHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.VA;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "Solemnity of Mary, Mother of God",
                    LocalName = "Maria Santissima Madre di Dio",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Epifania del Signore",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 11),
                    EnglishName = "Anniversary of the foundation of Vatican City",
                    LocalName = "Anniversario della istituzione dello Stato della Città del Vaticano",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 13),
                    EnglishName = "Anniversary of the election of Pope Francis",
                    LocalName = "Anniversario dell'Elezione del Santo Padre",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 19),
                    EnglishName = "Saint Joseph's Day",
                    LocalName = "San Giuseppe",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 23),
                    EnglishName = "Saint George",
                    LocalName = "Onomastico del Santo Padre",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Saint Joseph the Worker",
                    LocalName = "San Giuseppe lavoratore",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 29),
                    EnglishName = "Saints Peter and Paul",
                    LocalName = "Santi Pietro e Paolo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Assunzione di Maria in Cielo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 8),
                    EnglishName = "Nativity of Mary",
                    LocalName = "Festa della natività della madonna",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints",
                    LocalName = "Tutti i santi, Ognissanti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Immacolata Concezione",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Natale",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Santo Stefano",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterMonday("Lunedì dell'Angelo", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Maria Santissima Madre di Dio", "Solemnity of Mary, Mother of God", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Epifania del Signore", "Epiphany", countryCode));
            //items.Add(new Holiday(year, 2, 11, "Anniversario della istituzione dello Stato della Città del Vaticano", "Anniversary of the foundation of Vatican City", countryCode));
            //items.Add(new Holiday(year, 3, 13, "Anniversario dell'Elezione del Santo Padre", "Anniversary of the election of Pope Francis", countryCode));
            //items.Add(new Holiday(year, 3, 19, "San Giuseppe", "Saint Joseph's Day", countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Lunedì dell'Angelo", year, countryCode));
            //items.Add(new Holiday(year, 4, 23, "Onomastico del Santo Padre", "Saint George", countryCode));
            //items.Add(new Holiday(year, 5, 1, "San Giuseppe lavoratore", "Saint Joseph the Worker", countryCode));
            //items.Add(new Holiday(year, 6, 29, "Santi Pietro e Paolo", "Saints Peter and Paul", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Assunzione di Maria in Cielo", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 9, 8, "Festa della natività della madonna", "Nativity of Mary", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Tutti i santi, Ognissanti", "All Saints", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Immacolata Concezione", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Natale", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Santo Stefano", "St. Stephen's Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Vatican_City"
            };
        }
    }
}
