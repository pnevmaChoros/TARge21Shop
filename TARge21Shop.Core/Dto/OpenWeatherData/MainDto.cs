using System.Text.Json.Serialization;

namespace TARge21Shop.Core.Dto.OpenWeatherData
{
	public class MainDto
	{
		public double Temp { get; set; }

		public double Feels_Like { get; set; }

		public double Temp_Min { get; set; }

		public double Temp_Max { get; set; }

		public int Pressure { get; set; }
		public int Humidity { get; set; }

	}
}
