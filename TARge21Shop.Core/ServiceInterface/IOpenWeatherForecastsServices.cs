using TARge21Shop.Core.Dto.OpenWeatherData;

namespace TARge21Shop.Core.ServiceInterface
{
	public interface IOpenWeatherForecastsServices
	{
		Task<OpenWeatherResultDto> OpenWeatherDetails(OpenWeatherResultDto dto);
	}
}
