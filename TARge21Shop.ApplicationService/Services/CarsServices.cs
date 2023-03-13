using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationService.Services
{
	public class CarsServices : ICarsServices
	{
		private readonly TARge21ShopContext _context;

		public CarsServices(TARge21ShopContext context)
		{
			_context = context;
		}


		public async Task<Car> Add(CarDto dto)
		{
			var domain = new Car()
			{
				Id = Guid.NewGuid(),
				Mark = dto.Mark,
				Model = dto.Model,
				Type = dto.Type,
				Color = dto.Color,
				Passengers = dto.Passengers,
				Weight = dto.Weight,
				Manual = dto.Manual,
				EnginePower = dto.EnginePower,
				ReleseDate = DateTime.Now,
				CreatedAt = DateTime.Now,
			};

			await _context.Cars.AddAsync(domain);
			await _context.SaveChangesAsync();

			return domain;
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
