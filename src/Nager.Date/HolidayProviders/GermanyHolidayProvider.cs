using Nager.Date.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Nager.Date.Extensions;
using Nager.Date.ReligiousProviders;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Germany HolidayProvider
    /// </summary>
    internal class GermanyHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Germany HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GermanyHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "DE-BW", "Baden-Württemberg" },
                { "DE-BY", "Bayern" },
                { "DE-BE", "Berlin" },
                { "DE-BB", "Brandenburg" },
                { "DE-HB", "Bremen" },
                { "DE-HH", "Hamburg" },
                { "DE-HE", "Hessen" },
                { "DE-MV", "Mecklenburg-Vorpommern" },
                { "DE-NI", "Niedersachsen" },
                { "DE-NW", "Nordrhein-Westfalen" },
                { "DE-RP", "Rheinland-Pfalz" },
                { "DE-SL", "Saarland" },
                { "DE-SN", "Sachsen" },
                { "DE-ST", "Sachsen-Anhalt" },
                { "DE-SH", "Schleswig-Holstein" },
                { "DE-TH", "Thüringen" }
            };
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.DE;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new Holiday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode, 1967, new string[] { "DE-BW", "DE-BY", "DE-ST" }));
            items.Add(this._catholicProvider.GoodFriday("Karfreitag", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Ostersonntag", year, countryCode).SetCounties("DE-BB", "DE-HE"));
            items.Add(this._catholicProvider.EasterMonday("Ostermontag", year, countryCode).SetLaunchYear(1642));
            items.Add(new Holiday(year, 5, 1, "Tag der Arbeit", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Christi Himmelfahrt", year, countryCode));
            items.Add(this._catholicProvider.Pentecost("Pfingstsonntag", year, countryCode).SetCounties("DE-BB", "DE-HE"));
            items.Add(this._catholicProvider.WhitMonday("Pfingstmontag", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Fronleichnam", year, countryCode).SetCounties("DE-BW", "DE-BY", "DE-HE", "DE-NW", "DE-RP", "DE-SL"));
            items.Add(new Holiday(year, 8, 15, "Mariä Himmelfahrt", "Assumption Day", countryCode, null, new string[] { "DE-SL" }));
            items.Add(new Holiday(year, 10, 3, "Tag der Deutschen Einheit", "German Unity Day", countryCode));
            items.Add(new Holiday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode, null, new string[] { "DE-BW", "DE-BY", "DE-NW", "DE-RP", "DE-SL" }));
            items.Add(new Holiday(year, 12, 25, "Erster Weihnachtstag", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Zweiter Weihnachtstag", "St. Stephen's Day", countryCode));

            items.AddIfNotNull(this.InternationalWomensDay(year, CountryCode.DE));
            items.AddIfNotNull(this.PrayerDay(year, CountryCode.DE));
            items.AddIfNotNull(this.LiberationDay(year, CountryCode.DE));
            items.AddIfNotNull(this.ReformationDay(year, CountryCode.DE));
            items.AddIfNotNull(this.WorldChildrensDay(year, CountryCode.DE));

            return items.OrderBy(o => o.Date);
        }

        private Holiday WorldChildrensDay(int year, CountryCode countryCode)
        {
            if (year >= 2019)
            {
                return new Holiday(year, 9, 20, "Weltkindertag", "World Children's Day", countryCode, 2019, new string[] { "DE-TH" });
            }

            return null;
        }

        private Holiday InternationalWomensDay(int year, CountryCode countryCode)
        {
            var localName = "Internationaler Frauentag";
            var englishName = "International Women's Day";

            if (year >= 2019 && year <= 2022)
            {
                return new Holiday(year, 3, 8, localName, englishName, countryCode, 2019, new string[] { "DE-BE" });
            }

            if (year >= 2023)
            {
                return new Holiday(year, 3, 8, localName, englishName, countryCode, 2019, new string[] { "DE-BE", "DE-MV" });
            }

            return null;
        }

        private Holiday ReformationDay(int year, CountryCode countryCode)
        {
            var localName = "Reformationstag";
            var englishName = "Reformation Day";

            if (year == 2017)
            {
                //In commemoration of the 500th anniversary of the beginning of the Reformation, it was unique as a whole German holiday
                return new Holiday(year, 10, 31, localName, englishName, countryCode, null);
            }

            var counties = new List<string> { "DE-BB", "DE-MV", "DE-SN", "DE-ST", "DE-TH" };

            if (year >= 2018)
            {
                counties.AddRange(new[] { "DE-HB", "DE-HH", "DE-NI", "DE-SH" });
            }

            return new Holiday(year, 10, 31, localName, englishName, countryCode, null, counties.ToArray());
        }

        private Holiday PrayerDay(int year, CountryCode countryCode)
        {
            var dayOfPrayer = this._catholicProvider.AdventSunday(year).AddDays(-11);
            var localName = "Buß- und Bettag";
            var englishName = "Repentance and Prayer Day";

            if (year >= 1934 && year < 1939)
            {
                return new Holiday(dayOfPrayer, localName, englishName, countryCode);
            }

            else if (year >= 1945 && year <= 1980)
            {
                return new Holiday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "DE-BW", "DE-BE", "DE-HB", "DE-HH", "DE-HE", "DE-NI", "DE-NW", "DE-RP", "DE-SL", "DE-SH" });
            }

            else if (year >= 1981 && year <= 1989)
            {
                return new Holiday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "DE-BW", "DE-BY", "DE-BE", "DE-HB", "DE-HH", "DE-HE", "DE-NI", "DE-NW", "DE-RP", "DE-SL", "DE-SH" });
            }

            else if (year >= 1990 && year <= 1994)
            {
                return new Holiday(dayOfPrayer, localName, englishName, countryCode);
            }

            else if (year >= 1995)
            {
                return new Holiday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "DE-SN" });
            }

            return null;
        }

        private Holiday LiberationDay(int year, CountryCode countryCode)
        {
            if (year == 2020)
            {
                return new Holiday(new DateTime(2020, 5, 8), "Tag der Befreiung", "Liberation Day", countryCode, null, new string[] { "DE-BE" });
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://de.wikipedia.org/wiki/Gesetzliche_Feiertage_in_Deutschland",
            };
        }
    }
}