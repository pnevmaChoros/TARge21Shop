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
			string apikey = "a103a88260c8e1470f20d48d90d01bb3";
			var url = $"https://api.openweathermap.org/data/2.5/weather?q=Tallinn&appid=a103a88260c8e1470f20d48d90d01bb3&units=metric";

			using (WebClient client = new WebClient())
			{
				string json = client.DownloadString(url);

				OpenWeatherRootDto openWeatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

				dto.Longitude = openWeatherInfo.Coord.Longitude;
				dto.Latitude = openWeatherInfo.Coord.Latitude;

				dto.WeatherId = openWeatherInfo.Weather[0].Id;
				dto.Main = openWeatherInfo.Weather[0].Main;
				dto.Description = openWeatherInfo.Weather[0].Description;
				dto.Icon = openWeatherInfo.Weather[0].Icon;

				dto.Base = openWeatherInfo.Base;

				dto.Temperature = openWeatherInfo.Main.Temperature;
				dto.FeelsLike = openWeatherInfo.Main.FeelsLike;
				dto.TempMin = openWeatherInfo.Main.TempMin;
				dto.TempMax = openWeatherInfo.Main.TempMax;
				dto.Pressure = openWeatherInfo.Main.Pressure;
				dto.Humidity = openWeatherInfo.Main.Humidity;

				dto.Visibility = openWeatherInfo.Visibility;

				dto.Speed = openWeatherInfo.Wind.Speed;
				dto.Degree = openWeatherInfo.Wind.Degree;

				//dto.All = openWeatherInfo.Cloud.All;

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
