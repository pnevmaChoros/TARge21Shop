namespace TARge21Shop.Models.OpenWeather
{
	public class OpenWeatherViewModel
	{
		public double Longitude { get; set; }
		public double Latitude { get; set; }

		public int WeatherId { get; set; }
		public string Main { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }

		public string Base { get; set; }
		public double Temperature { get; set; }
		public double FeelsLike { get; set; }
		public double TempMin { get; set; }
		public double TempMax { get; set; }
		public int Pressure { get; set; }
		public int Humidity { get; set; }

		public int Visibility { get; set; }

		public double Speed { get; set; }
		public int Degree { get; set; }

		public int All { get; set; }

		public int Dt { get; set; }

		public int Type { get; set; }
		public int SysId { get; set; }
		public string Country { get; set; }
		public int Sunrise { get; set; }
		public int Sunset { get; set; }

		public int Timezone { get; set; }

		public int Id { get; set; }

		public string Name { get; set; }

		public int Cod { get; set; }
	}
}
