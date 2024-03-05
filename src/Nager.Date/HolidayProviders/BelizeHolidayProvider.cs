using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Belize HolidayProvider
    /// </summary>
    internal sealed class BelizeHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Belize HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BelizeHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BZ;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var saturday2MondayObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2)
            };

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(-3),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 9),
                    EnglishName = "Baron Bliss Day",
                    LocalName = "Baron Bliss Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 24),
                    EnglishName = "Commonwealth Day",
                    LocalName = "Commonwealth Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 10),
                    EnglishName = "Saint George's Caye Day",
                    LocalName = "Saint George's Caye Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 21),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Day of the Americas",
                    LocalName = "Day of the Americas",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 19),
                    EnglishName = "Garifuna Settlement Day",
                    LocalName = "Garifuna Settlement Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSaturday("Holy Saturday", year),
                this._catholicProvider.EasterSunday("Easter Sunday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);


            //var items = new List<Holiday>();

            //#region New Year's Day

            //var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            //items.Add(new Holiday(newYearsDay, "New Year's Day", "New Year's Day", countryCode));

            //#endregion

            //#region Baron Bliss Day

            //var baronBlissDay = new DateTime(year, 3, 9).ShiftWeekdays(
            //    tuesday: tuesday => tuesday.AddDays(-1),
            //    wednesday: wednesday => wednesday.AddDays(-2),
            //    thursday: thursday => thursday.AddDays(-3)
            //    );
            //items.Add(new Holiday(baronBlissDay, "Baron Bliss Day", "Baron Bliss Day", countryCode));

            //#endregion

            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));

            //#region Labour Day

            //var labourDay = new DateTime(year, 5, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            //items.Add(new Holiday(labourDay, "Labour Day", "Labour Day", countryCode));

            //#endregion

            //#region Commonwealth Day

            //var commonwealthDay = new DateTime(year, 5, 24).ShiftWeekdays(
            //    tuesday: tuesday => tuesday.AddDays(-1),
            //    wednesday: wednesday => wednesday.AddDays(-2),
            //    thursday: thursday => thursday.AddDays(-3)
            //    );
            //items.Add(new Holiday(commonwealthDay, "Commonwealth Day", "Commonwealth Day", countryCode));

            //#endregion

            //#region Saint George's Caye Day

            //var saintGeorgesCayeDay = new DateTime(year, 9, 10).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            //items.Add(new Holiday(saintGeorgesCayeDay, "Saint George's Caye Day", "Saint George's Caye Day", countryCode));

            //#endregion

            //#region Independence Day

            //var independenceDay = new DateTime(year, 9, 21).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            //items.Add(new Holiday(independenceDay, "Independence Day", "Independence Day", countryCode));

            //#endregion

            //#region Day of the Americas

            //var dayOfTheAmericas = new DateTime(year, 10, 12).ShiftWeekdays(
            //    tuesday: tuesday => tuesday.AddDays(-1),
            //    wednesday: wednesday => wednesday.AddDays(-2),
            //    thursday: thursday => thursday.AddDays(-3)
            //    );
            //items.Add(new Holiday(dayOfTheAmericas, "Day of the Americas", "Day of the Americas", countryCode));

            //#endregion

            //#region Garifuna Settlement Day

            //var garifunaSettlementDay = new DateTime(year, 11, 19).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            //items.Add(new Holiday(garifunaSettlementDay, "Garifuna Settlement Day", "Garifuna Settlement Day", countryCode));

            //#endregion

            //#region Christmas Day

            //var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            //items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            //#endregion

            //    #region Boxing Day

            //    var boxingDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday);
            //    items.Add(new Holiday(boxingDay, "Boxing Day", "Boxing Day", countryCode));

            //    #endregion

            //    return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belize"
            };
        }
    }
}
