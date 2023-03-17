using System.Text.Json.Serialization;

namespace TARge21Shop.Core.Dto.OpenWeatherData
{
	public class WindDto
	{
		public double Speed { get; set; }

		public int Deg { get; set; }
	}
}
