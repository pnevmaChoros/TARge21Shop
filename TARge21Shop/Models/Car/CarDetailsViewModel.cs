namespace TARge21Shop.Models.Car
{
	public class CarDetailsViewModel
	{
		public Guid? Id { get; set; }
		public string Mark { get; set; }
		public string Model { get; set; }
		public string Type { get; set; }
		public string Color { get; set; }
		public int Passengers { get; set; }
		public int Weight { get; set; }
		public bool Manual { get; set; }
		public int EnginePower { get; set; }

		public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();

		public DateTime ReleseDate { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
