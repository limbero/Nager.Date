using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Spain HolidayProvider
    /// </summary>
    internal class SpainHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Spain HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SpainHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            //https://en.wikipedia.org/wiki/ISO_3166-2:ES

            return new Dictionary<string, string>
            {
                { "ES-AN", "Andalusia" },
                { "ES-AR", "Aragon" },
                { "ES-AS", "Principality of Asturias" },
                { "ES-CN", "Canary Islands" },
                { "ES-CB", "Cantabria" },
                { "ES-CL", "Castile and León" },
                { "ES-CM", "Castile-La Mancha" },
                { "ES-CT", "Catalonia" },
                { "ES-EX", "Extremadura" },
                { "ES-GA", "Galicia" },
                { "ES-IB", "Balearic Islands" },
                { "ES-RI", "La Rioja" },
                { "ES-MD", "Community of Madrid" },
                { "ES-MC", "Region of Murcia" },
                { "ES-NC", "Chartered Community of Navarre" },
                { "ES-PV", "Basque Country" },
                { "ES-VC", "Valencian Community" },
                //Not a community
                //{ "ES-CE", "Ceuta" },
                //{ "ES-ML", "Melilla" },
            };
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.ES;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 6, "Día de Reyes / Epifanía del Señor", "Epiphany", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Fiesta del trabajo", "Labour Day", countryCode));
            items.Add(new Holiday(year, 10, 12, "Fiesta Nacional de España", "Fiesta Nacional de España", countryCode));
            items.Add(new Holiday(year, 11, 1, "Día de todos los Santos", "All Saints Day", countryCode));
            items.Add(new Holiday(year, 12, 6, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new Holiday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));

            items.AddIfNotNull(this.ChristmasDay(year, countryCode));
            items.AddIfNotNull(this.CorpusChristi(year, countryCode));
            items.AddIfNotNull(this.EasterMonday(year, countryCode));
            items.AddIfNotNull(this.MaundyThursday(year, countryCode));

            items.AddIfNotNull(this.Assumption(year, countryCode));
            items.AddIfNotNull(this.CarnivalTuesday(year, countryCode));
            items.AddIfNotNull(this.CastileAndLeonDay(year, countryCode));
            items.AddIfNotNull(this.DayOfAndalucia(year, countryCode));
            items.AddIfNotNull(this.DayOfAragon(year, countryCode));
            items.AddIfNotNull(this.DayOfAsturias(year, countryCode));
            items.AddIfNotNull(this.DayOfCastillaLaMancha(year, countryCode));
            items.AddIfNotNull(this.DayOfExtremadura(year, countryCode));
            items.AddIfNotNull(this.DayOfLaRioja(year, countryCode));
            items.AddIfNotNull(this.DayOfMadrid(year, countryCode));
            items.AddIfNotNull(this.DayOfMurcia(year, countryCode));
            items.AddIfNotNull(this.DayOfTheBalearicIslands(year, countryCode));
            items.AddIfNotNull(this.DayOfTheCanaryIslands(year, countryCode));
            items.AddIfNotNull(this.DayOfTheCantabrianInstitutions(year, countryCode));
            items.AddIfNotNull(this.DayOfTheValencianCommunity(year, countryCode));
            items.AddIfNotNull(this.GalicianLiteratureDay(year, countryCode));
            items.AddIfNotNull(this.LaBienAparecida(year, countryCode));
            items.AddIfNotNull(this.NationalDayOfCatalonia(year, countryCode));
            items.AddRangeIfNotNull(this.NewYearsDay(year, countryCode));
            items.AddIfNotNull(this.SantiagoApostol(year, countryCode));
            items.AddIfNotNull(this.StJohnsDay(year, countryCode));
            items.AddIfNotNull(this.StJosephsDay(year, countryCode));
            items.AddIfNotNull(this.StStephensDay(year, countryCode));
            items.AddIfNotNull(this.WhitMonday(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday[] NewYearsDay(int year, CountryCode countryCode)
        {
            var newYearsDay = new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode, 1967);

            switch (year)
            {
                case 2023:
                    var newYearsDay2 = new Holiday(year, 1, 2, "Año Nuevo", "New Year's Day", countryCode, null, new string[] { "ES-AN", "ES-AR", "ES-AS", "ES-CL", "ES-MC" });

                    return new Holiday[]
                    {
                        newYearsDay,
                        newYearsDay2
                    };
            }

            return new Holiday[]
            {
                newYearsDay
            };
        }

        private Holiday EasterMonday(int year, CountryCode countryCode)
        {
            return this._catholicProvider.EasterMonday("Lunes de Pascua", year, countryCode).SetLaunchYear(1642).SetCounties("ES-CT", "ES-IB", "ES-RI", "ES-NC", "ES-PV", "ES-VC");
        }

        private Holiday CorpusChristi(int year, CountryCode countryCode)
        {
            return this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode).SetCounties("ES-CM");
        }

        private Holiday MaundyThursday(int year, CountryCode countryCode)
        {
            return this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode).SetCounties("ES-AN", "ES-AR", "ES-CL", "ES-CM", "ES-CN", "ES-EX", "ES-GA", "ES-IB", "ES-RI", "ES-MD", "ES-MC", "ES-NC", "ES-AS", "ES-PV", "ES-CB");
        }

        private Holiday ChristmasDay(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                return new Holiday(christmasDay, "Navidad", "Christmas Day", countryCode, null, new string[] { "ES-AN", "ES-AR", "ES-AS", "ES-CN", "ES-CB", "ES-CL", "ES-CM", "ES-EX", "ES-GA", "ES-IB", "ES-RI", "ES-MD", "ES-MC", "ES-NC" });
            }

            return new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode);
        }

        private Holiday WhitMonday(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                var whitMonday = this._catholicProvider.WhitMonday("Lunes de Pascua Granada", year, countryCode);
                whitMonday.SetCounties("ES-CT");
                return whitMonday;
            }

            return null;
        }

        private Holiday Assumption(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 8, 15).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            return new Holiday(date, "Asunción", "Assumption", countryCode);
        }

        private Holiday DayOfMadrid(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 5, 2).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            return new Holiday(date, "Fiesta de la Comunidad de Madrid", "Day of Madrid", countryCode, null, new string[] { "ES-MD" });
        }

        private Holiday StJosephsDay(int year, CountryCode countryCode)
        {
            if (year < 2000)
            {
                return null;
            }

            string[] counties;

            switch (year)
            {
                case 2000:
                case 2001:
                case 2002:
                case 2003:
                case 2004:
                case 2005:
                case 2006:
                case 2007:
                case 2008:
                case 2009:
                case 2010:
                case 2011:
                case 2012:
                case 2013:
                case 2014:
                    counties = new string[] { "ES-AR", "ES-CL", "ES-CM", "ES-EX", "ES-GA", "ES-MD", "ES-PV", "ES-VC" };
                    break;
                case 2015:
                    counties = new string[] { "ES-CM", "ES-MD", "ES-PV", "ES-VC" };
                    break;
                case 2016:
                    counties = new string[] { "ES-PV", "ES-VC" };
                    break;
                case 2017:
                    counties = new string[] { "ES-EX", "ES-MD" };
                    break;
                case 2018:
                case 2019:
                    counties = new string[] { "ES-GA", "ES-PV", "ES-VC" };
                    break;
                case 2020:
                    counties = new string[] { "ES-CM", "ES-GA", "ES-PV", "ES-VC" };
                    break;
                case 2021:
                    counties = new string[] { "ES-EX", "ES-GA", "ES-MD", "ES-PV", "ES-VC" };
                    break;
                case 2022:
                    counties = new string[] { "ES-VC" };
                    break;
                case 2023:
                    counties = new string[] { "ES-MD" };
                    break;
                default:
                    return null;
            }

            return new Holiday(year, 3, 19, "San José", "St. Joseph's Day", countryCode, null, counties)
                .Shift(saturday => saturday, sunday => sunday.AddDays(1)); ;
        }

        private Holiday SantiagoApostol(int year, CountryCode countryCode)
        {
            string[] counties;

            switch (year)
            {
                case 2017:
                    counties = new string[] { "ES-CL", "ES-CN", "ES-GA", "ES-MD", "ES-PV" };
                    break;
                case 2018:
                    counties = new string[] { "ES-GA" };
                    break;
                case 2019:
                    counties = new string[] { "ES-GA", "ES-PV" };
                    break;
                case 2020:
                    counties = new string[] { "ES-GA", "ES-PV" };
                    break;
                case 2022:
                    counties = new string[] { "ES-GA", "ES-MD", "ES-PV" };
                    break;
                case 2023:
                    counties = new string[] { "ES-CL", "ES-GA", "ES-NC", "ES-PV" };
                    break;
                case 2024:
                case 2025:
                case 2026:
                case 2027:
                    counties = new string[] { "ES-GA", "ES-PV" };
                    break;
                default:
                    return null;
            }

            return new Holiday(year, 7, 25, "Santiago Apóstol", "Santiago Apóstol", countryCode, null, counties);
        }

        private Holiday StStephensDay(int year, CountryCode countryCode)
        {
            return new Holiday(year, 12, 26, "Sant Esteve", "St. Stephen's Day", countryCode, null, new string[] { "ES-CT" });
        }

        private Holiday DayOfTheValencianCommunity(int year, CountryCode countryCode)
        {
            return new Holiday(year, 10, 9, "Dia de la Comunitat Valenciana", "Day of the Valencian Community", countryCode, null, new string[] { "ES-VC" });
        }

        private Holiday LaBienAparecida(int year, CountryCode countryCode)
        {
            return new Holiday(year, 9, 15, "La Bien Aparecida", "Regional Holiday", countryCode, null, new string[] { "ES-CB" });
        }

        private Holiday NationalDayOfCatalonia(int year, CountryCode countryCode)
        {
            return new Holiday(year, 9, 11, "Diada Nacional de Catalunya", "National Day of Catalonia", countryCode, null, new string[] { "ES-CT" });
        }

        private Holiday DayOfExtremadura(int year, CountryCode countryCode)
        {
            return new Holiday(year, 9, 8, "Día de Extremadura", "Day of Extremadura", countryCode, null, new string[] { "ES-EX" });
        }

        private Holiday DayOfAsturias(int year, CountryCode countryCode)
        {
            return new Holiday(year, 9, 8, "Día de Asturias", "Day of Asturias", countryCode, null, new string[] { "ES-AS" });
        }

        private Holiday DayOfTheCantabrianInstitutions(int year, CountryCode countryCode)
        {
            return new Holiday(year, 7, 28, "Día de las Instituciones de Cantabria", "Day of the Cantabrian Institutions", countryCode, null, new string[] { "ES-CB" });
        }

        private Holiday StJohnsDay(int year, CountryCode countryCode)
        {
            return new Holiday(year, 6, 24, "Sant Joan", "St. John's Day", countryCode, null, new string[] { "ES-CT", "ES-VC" });
        }

        private Holiday DayOfLaRioja(int year, CountryCode countryCode)
        {
            return new Holiday(year, 6, 9, "Día de La Rioja", "Day of La Rioja", countryCode, null, new string[] { "ES-RI" });
        }

        private Holiday DayOfMurcia(int year, CountryCode countryCode)
        {
            return new Holiday(year, 6, 9, "Día de la Región de Murcia", "Day of Murcia", countryCode, null, new string[] { "ES-MC" });
        }

        private Holiday DayOfCastillaLaMancha(int year, CountryCode countryCode)
        {
            return new Holiday(year, 5, 31, "Día de la Región Castilla-La Mancha", "Day of Castilla-La Mancha", countryCode, null, new string[] { "ES-CM" });
        }

        private Holiday CastileAndLeonDay(int year, CountryCode countryCode)
        {
            switch (year)
            {
                case 2023:
                    return null;
            }

            return new Holiday(year, 4, 23, "Día de Castilla y León", "Castile and León Day", countryCode, null, new string[] { "ES-CL" });
        }

        private Holiday GalicianLiteratureDay(int year, CountryCode countryCode)
        {
            return new Holiday(year, 5, 17, "Día das Letras Galegas", "Galician Literature Day", countryCode, null, new string[] { "ES-GA" });
        }

        private Holiday DayOfAragon(int year, CountryCode countryCode)
        {
            return new Holiday(year, 4, 23, "San Jorge (Día de Aragón)", "Day of Aragón", countryCode, null, new string[] { "ES-AR" })
                .Shift(saturday => saturday, sunday => sunday.AddDays(1)); ;
        }

        private Holiday DayOfTheBalearicIslands(int year, CountryCode countryCode)
        {
            return new Holiday(year, 3, 1, "Dia de les Illes Balears", "Day of the Balearic Islands", countryCode, null, new string[] { "ES-IB" });
        }

        private Holiday DayOfAndalucia(int year, CountryCode countryCode)
        {
            return new Holiday(year, 2, 28, "Día de Andalucía", "Day of Andalucía", countryCode, null, new string[] { "ES-AN" });
        }

        private Holiday DayOfTheCanaryIslands(int year, CountryCode countryCode)
        {
            return new Holiday(year, 5, 30, "Día de Canarias", "Day of the Canary Islands", countryCode, null, new string[] { "ES-CN" });
        }

        private Holiday CarnivalTuesday(int year, CountryCode countryCode)
        {
            switch (year)
            {
                case 2023:
                    return new Holiday(year, 2, 21, "Martes de Carnaval", "Carnival Tuesday", countryCode, null, new string[] { "ES-EX" });
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Spain",
                "https://www.boe.es/boe/dias/2020/11/02/pdfs/BOE-A-2020-13343.pdf",
                "https://www.boe.es/diario_boe/txt.php?id=BOE-A-2021-17113"
            };
        }
    }
}