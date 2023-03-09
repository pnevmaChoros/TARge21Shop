namespace TARge21Shop.Core.Dto
{
    public class WeatherResultDto
    {
        //public bool DayHasPreciptation;

        public DateTime EffectiveDate { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public int EndEpochDate { get; set; }

        public string MobileLink { get; set; }
        public string Link { get; set; }

        public DateTime DailyForecastsDay { get; set; }
        public int DailyForecastsEpochDate { get; set; }

        public double TempMinValue { get; set; }
        public string TempMinUnit { get; set; }
        public int TempMinUnitType { get; set; }

        public double TempMaxValue { get; set; }
        public string TempMaxUnit { get; set; }
        public int TempMaxUnitType { get; set; }

        public int DayIcon { get; set; }
        public bool DayHasPercipitation { get; set; }
        public string DayIconPhrase { get; set; }
        public string DayPrecipitationType { get; set; }
        public string DayPrecipitationIntensity { get; set; }

        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; }
        public bool NightHasPercipitation { get; set; }
        public string NightPrecipitationType { get; set; }
        public string NightPrecipitationIntensity { get; set; }

        //public DateTime Date { get; set; }
        //public int EpochDate { get; set; }
        //public Temperatures Temperature { get; set; }
        //public Day Day { get; set; }
        //public Night Night { get; set; }
        //public List<string> Sources { get; set; }
        //public string MobileLink { get; set; }
        //public string Link { get; set; }


        //public int Icon { get; set; }
        //public string IconPhrase { get; set; }
        //public bool HasPrecipitation { get; set; }
        //public string PrecipitationType { get; set; }
        //public string PrecipitationIntensity { get; set; }

        //public double Value { get; set; }
        //public string Unit { get; set; }
        //public int UnitType { get; set; }

        //public Temperature Minimum { get; set; }
        //public Temperature Maximum { get; set; }

        //public DateTime EffectiveDate { get; set; }
        //public int EffectiveEpochDate { get; set; }
        //public int Severity { get; set; }
        //public string Text { get; set; }
        //public string Category { get; set; }
        //public DateTime EndDate { get; set; }
        //public int EndEpochDate { get; set; }

        //public string MobileLink { get; set; }
        //public string Link { get; set; }

    }
}
