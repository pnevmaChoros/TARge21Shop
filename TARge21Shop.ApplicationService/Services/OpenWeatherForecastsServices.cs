using Nancy.Json;
using System.Net;
using TARge21Shop.Core.Dto.OpenWeatherData;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationService.Services
{
	public class OpenWeatherForecastsServices : IOpenWeatherForecastsServices
	{
		public async Task<OpenWeatherResultDto> OpenWeatherDetails(OpenWeatherResultDto dto)
		{
			//string apikey = "a103a88260c8e1470f20d48d90d01bb3";
			var url = $"https://api.openweathermap.org/data/2.5/weather?q=Tallinn&appid=a103a88260c8e1470f20d48d90d01bb3&units=metric";

			using (WebClient client = new WebClient())
			{
				string json = client.DownloadString(url);

				OpenWeatherRootDto openWeatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

				dto.Longitude = openWeatherInfo.Coord.Lon;
				dto.Latitude = openWeatherInfo.Coord.Lat;

				dto.WeatherId = openWeatherInfo.Weather[0].Id;
				dto.Main = openWeatherInfo.Weather[0].Main;
				dto.Description = openWeatherInfo.Weather[0].Description;
				dto.Icon = openWeatherInfo.Weather[0].Icon;

				dto.Base = openWeatherInfo.Base;

				dto.Temperature = openWeatherInfo.Main.Temp;
				dto.FeelsLike = openWeatherInfo.Main.Feels_Like;
				dto.TempMin = openWeatherInfo.Main.Temp_Min;
				dto.TempMax = openWeatherInfo.Main.Temp_Max;
				dto.Pressure = openWeatherInfo.Main.Pressure;
				dto.Humidity = openWeatherInfo.Main.Humidity;

				dto.Visibility = openWeatherInfo.Visibility;

				dto.Speed = openWeatherInfo.Wind.Speed;
				dto.Degree = openWeatherInfo.Wind.Deg;

				dto.All = openWeatherInfo.Clouds.All;

				dto.Dt = openWeatherInfo.Dt;

				dto.Type = openWeatherInfo.Sys.Type;
				dto.SysId = openWeatherInfo.Sys.Id;
				dto.Country = openWeatherInfo.Sys.Country;
				dto.Sunrise = openWeatherInfo.Sys.Sunrise;
				dto.Sunset = openWeatherInfo.Sys.Sunset;

				dto.Timezone = openWeatherInfo.Timezone;
				dto.Id = openWeatherInfo.Id;
				dto.Name = openWeatherInfo.Name;
				dto.Cod = openWeatherInfo.Cod;
			}

			return dto;
		}
	}
}
