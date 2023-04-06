using Microsoft.EntityFrameworkCore;
using System.Drawing;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationService.Services
{
	public class CarsServices : ICarsServices
	{
		private readonly TARge21ShopContext _context;
		private readonly IFilesServices _file;

		public CarsServices
			(
				TARge21ShopContext context, 
				IFilesServices file
			)
		{
			_context = context;
			_file = file;
		}


		public async Task<Car> Add(CarDto dto)
		{
			Car car = new Car();
			FileToDatabase file = new FileToDatabase();

			car.Id = Guid.NewGuid();
			car.Mark = dto.Mark;
			car.Model = dto.Model;
			car.Type = dto.Type;
			car.Color = dto.Color;
			car.Passengers = dto.Passengers;
			car.Weight = dto.Weight;
			car.Manual = dto.Manual;
			car.EnginePower = dto.EnginePower;
			car.ReleseDate = DateTime.Now;
			car.CreatedAt = DateTime.Now;

			if(dto.Files != null)
			{
				_file.UploadFileToDatabase(dto, car);
			}

			await _context.Cars.AddAsync(car);
			await _context.SaveChangesAsync();

			return car;
		}


		public async Task<Car> GetUpdate(Guid id)
		{
			var result = await _context.Cars
				.FirstOrDefaultAsync(x => x.Id == id);

			return result;
		}

		public async Task<Car> Update(CarDto dto)
		{
			var domain = new Car()
			{
				Id = dto.Id,
				Mark = dto.Mark,
				Model = dto.Model,
				Type = dto.Type,
				Color = dto.Color,
				Passengers = dto.Passengers,
				Weight = dto.Weight,
				Manual = dto.Manual,
				EnginePower = dto.EnginePower,
				ReleseDate = dto.ReleseDate,
				CreatedAt = DateTime.Now
			};

			_context.Cars.Update(domain);
			await _context.SaveChangesAsync();

			return domain;
		}


		public async Task<Car> Delete(Guid id)
		{
			var carId = await _context.Cars
				.FirstOrDefaultAsync(x => x.Id ==id);

			_context.Cars.Remove(carId);
			await _context.SaveChangesAsync();

			return carId;
		}


		public async Task<Car> GetAsync(Guid id)
		{
			var result = await _context.Cars
				.FirstOrDefaultAsync (x => x.Id == id);

			return result;
		}


	}
}
