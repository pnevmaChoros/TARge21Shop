﻿namespace TARge21Shop.Core.Dto.OpenWeatherData
{
	public class OpenWeatherRootDto
	{
		public CoordDto Coord { get; set; }
		public List<WeatherDto> Weather { get; set; }
		public MainDto Main { get; set; }
		public WindDto Wind { get; set; }
		public CloudsDto Clouds { get; set; }
		public SysDto Sys { get; set; }
		
		public string Base { get; set; }
		public int Visibility { get; set; }
		public int Dt { get; set; }
		public int Timezone { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int Cod { get; set; }
	}
}
