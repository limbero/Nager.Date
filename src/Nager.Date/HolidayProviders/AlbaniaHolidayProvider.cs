using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Albania HolidayProvider
    /// </summary>
    internal class AlbaniaHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Albania HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        /// <param name="orthodoxProvider"></param>
        public AlbaniaHolidayProvider(
            ICatholicProvider catholicProvider,
            IOrthodoxProvider orthodoxProvider)
        {
            this._catholicProvider = catholicProvider;
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AL;

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Viti i Ri",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Viti i Ri",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 12),
                    EnglishName = "Summer Day",
                    LocalName = "Dita e Verës",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 22),
                    EnglishName = "Nowruz",
                    LocalName = "Dita e Sulltan Nevruzit",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Dita Ndërkombëtare e Punonjësve",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 19),
                    EnglishName = "Mother Teresa Day",
                    LocalName = "Dita e Nënë Terezës",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 28),
                    EnglishName = "Independence Day",
                    LocalName = "Dita e Pavarësisë",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 29),
                    EnglishName = "Liberation Day",
                    LocalName = "Dita e Çlirimit",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Youth Day",
                    LocalName = "Dita Kombëtare e Rinisë",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Krishtlindjet",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                this._catholicProvider.EasterSunday("Pashkët Katolike", year),
                this._catholicProvider.EasterMonday("Hënen e Pashkët Katolike", year),
                this._orthodoxProvider.EasterSunday("Pashkët Ortodokse", year),
                this._orthodoxProvider.EasterMonday("Hënen e Pashkët Ortodokse", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //TODO: Eid ul-Fitr is not implemented
            //TODO: Eid ul-Adha is not implemented


            //var items = new List<Holiday>();
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 1, 1, "Viti i Ri", "New Year's Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 1, 2, "Viti i Ri", "New Year's Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 3, 14, "Dita e Verës", "Summer Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 3, 22, "Dita e Sulltan Nevruzit", "Nowruz", countryCode)));
            //Catholic Easter and monday
            //items.Add(this._catholicProvider.EasterSunday("Pashkët Katolike", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Hënen e Pashkët Katolike", year, countryCode));
            ////Orthodox easter and monday            
            //items.Add(this._orthodoxProvider.EasterSunday("Pashkët Ortodokse", year, countryCode));
            //items.Add(this._orthodoxProvider.EasterMonday("Hënen e Pashkët Ortodokse", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Dita Ndërkombëtare e Punonjësve", "May Day", countryCode));


            //items.Add(this.ApplyShiftingRules(new Holiday(year, 10, 19, "Dita e Nënë Terezës", "Mother Teresa Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 11, 28, "Dita e Pavarësisë", "Independence Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 11, 29, "Dita e Çlirimit", "Liberation Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 12, 08, "Dita Kombëtare e Rinisë", "Youth Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 12, 25, "Krishtlindjet", "Christmas Day", countryCode)));

            //return items.OrderBy(o => o.Date);
        }

        //private Holiday ApplyShiftingRules(Holiday holiday)
        //{
        //    return holiday
        //        .Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
        //}

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Albania"
            };
        }
    }
}
