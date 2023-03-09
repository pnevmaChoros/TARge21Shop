using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastServices;


        public WeatherForecastsController
            (
            IWeatherForecastsServices weatherForcastServices
            )
        {
            _weatherForecastServices = weatherForcastServices;

        }


        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();

            return View(vm);
        }


        [HttpPost]
        public IActionResult ShowWeather(WeatherViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }

            return View(vm);
        }


        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new();
            WeatherViewModel vm = new();

            _weatherForecastServices.WeatherDetails(dto);

            vm.Date = dto.EffectiveDate;
            vm.EpochDate = dto.EffectiveEpochDate;
            vm.Serverity = dto.Severity;
            vm.Text = dto.Text;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;
            vm.Category = dto.Category;

            vm.Temperature.Minimum.Value = dto.TempMinValue;
            vm.Temperature.Minimum.Unit = dto.TempMinUnit;
            vm.Temperature.Minimum.UnitType = dto.TempMinUnitType;

            vm.Temperature.Maximum.Value = dto.TempMaxValue;
            vm.Temperature.Maximum.Unit = dto.TempMaxUnit;
            vm.Temperature.Maximum.UnitType = dto.TempMaxUnitType;

            vm.DayCycle.Icon = dto.DayIcon;
            vm.DayCycle.IconPhrase = dto.DayIconPhrase;
            vm.DayCycle.HasPrecipitation = dto.DayHasPercipitation;
            vm.DayCycle.PrecipitationType = dto.DayPrecipitationType;
            vm.DayCycle.PrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.NightCycle.Icon = dto.NightIcon;
            vm.NightCycle.IconPhrase = dto.NightIconPhrase;
            vm.NightCycle.HasPrecipitation = dto.NightHasPercipitation;
            vm.NightCycle.PrecipitationType = dto.NightPrecipitationType;
            vm.NightCycle.PrecipitationIntensity = dto.NightPrecipitationIntensity;


            return View(vm);
        }
    }
}
