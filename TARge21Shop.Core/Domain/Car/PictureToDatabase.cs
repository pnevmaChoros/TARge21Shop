﻿namespace TARge21Shop.Core.Domain.Car
{
	public class PictureToDatabase
	{
		public Guid Id { get; set; }
		public string ImageTitle { get; set; }
		public byte[] ImageData { get; set; }
		public Guid? CarId { get; set; }
	}
}
