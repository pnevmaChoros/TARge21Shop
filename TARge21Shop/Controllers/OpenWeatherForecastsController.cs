using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto.OpenWeatherData;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.OpenWeather;

namespace TARge21Shop.Controllers
{
	public class OpenWeatherForecastsController : Controller
	{
		private readonly IOpenWeatherForecastsServices _openWeatherForecastsServices;

		public OpenWeatherForecastsController
			(
				IOpenWeatherForecastsServices openWeatherForecastsServices
			)
		{
			_openWeatherForecastsServices = openWeatherForecastsServices;
		}


		public IActionResult Index()
		{
			OpenWeatherViewModel vm = new OpenWeatherViewModel();

			return View(vm);
		}


		[HttpPost]
		public IActionResult ShowWeather()
		{
			if(ModelState.IsValid)
			{
				return RedirectToAction("City", "OpenWeatherForecasts");
			}

			return View();
		}


		[HttpGet]
		public IActionResult City()
		{
			OpenWeatherResultDto dto = new();
			OpenWeatherViewModel vm = new();

			_openWeatherForecastsServices.OpenWeatherDetails(dto);

			vm.Longitude = dto.Longitude;
			vm.Latitude = dto.Latitude;

			vm.WeatherId = dto.WeatherId;
			vm.Main = dto.Main;
			vm.Description = dto.Description;
			vm.Icon = dto.Icon;
			
			vm.Base = dto.Base;

			vm.Temperature = dto.Temperature;
			vm.FeelsLike = dto.FeelsLike;
			vm.TempMin = dto.TempMin;
			vm.TempMax = dto.TempMax;
			vm.Pressure = dto.Pressure;
			vm.Humidity = dto.Humidity;

			vm.Visibility = dto.Visibility;

			vm.Speed = dto.Speed;
			vm.Degree = dto.Degree;

			vm.All = dto.All;

			vm.Dt = dto.Dt;

			vm.Type = dto.Type;
			vm.SysId = dto.SysId;
			vm.Country = dto.Country;
			vm.Sunrise = dto.Sunrise;
			vm.Sunset = dto.Sunset;

			vm.Timezone = dto.Timezone;
			vm.Id = dto.Id;
			vm.Name = dto.Name;
			vm.Cod = dto.Cod;

			return View(vm);
		}


	}
}
