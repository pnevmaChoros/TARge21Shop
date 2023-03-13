using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Car;

namespace TARge21Shop.Controllers
{
	public class CarsController : Controller
	{
		private readonly TARge21ShopContext _context;
		private readonly ICarsServices _carsServices;

		public CarsController
			(
				TARge21ShopContext context,
				ICarsServices carsServices
			)
		{
			_context = context;
			_carsServices = carsServices;
		}


		public IActionResult Index()
		{
			var result = _context.Cars
				.OrderByDescending(x => x.CreatedAt)
				.Select(x => new CarIndexViewModel
				{
					Id = x.Id,
					Mark = x.Mark,
					Model = x.Model,
					Type = x.Type,
					EnginePower = x.EnginePower
				});

			return View(result);
		}


		[HttpGet]
		public IActionResult Add()
		{
			CarEditViewModel car = new CarEditViewModel();

			return View("Edit", car);
		}


		[HttpPost]
		public async Task<IActionResult> Add(CarEditViewModel vm)
		{
			var dto = new CarDto()
			{
				Id = vm.Id,
				Mark = vm.Mark,
				Model = vm.Model,
				Type = vm.Type,
				Color = vm.Color,
				Passengers = vm.Passengers,
				Weight = vm.Weight,
				Manual = vm.Manual,
				EnginePower = vm.EnginePower,
				ReleseDate = vm.ReleseDate,
				CreatedAt = vm.CreatedAt
			};

			var result = await _carsServices.Add(dto);

			if(result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var car = await _carsServices.GetUpdate(id);

			if(car == null)
			{
				return NotFound();
			}

			var vm = new CarEditViewModel()
			{
				Id = car.Id,
				Mark = car.Mark,
				Model = car.Model,
				Type = car.Type,
				Color = car.Color,
				Passengers = car.Passengers,
				Weight = car.Weight,
				Manual = car.Manual,
				EnginePower = car.EnginePower,
				ReleseDate = car.ReleseDate,
				CreatedAt = car.CreatedAt
			};

			return View(vm);
		}


		[HttpPost]
		public async Task<IActionResult> Update(CarEditViewModel vm)
		{
			var dto = new CarDto()
			{
				Id = vm.Id,
				Mark = vm.Mark,
				Model = vm.Model,
				Type = vm.Type,
				Color = vm.Color,
				Passengers = vm.Passengers,
				Weight = vm.Weight,
				Manual = vm.Manual,
				EnginePower = vm.EnginePower,
				ReleseDate = vm.ReleseDate,
				CreatedAt = vm.CreatedAt
			};

			var result = await _carsServices.Update(dto);

			if(result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}


		[HttpPost]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var carId = await _carsServices.Delete(id);

			if(carId == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var car = await _carsServices.GetAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			var vm = new CarDetailsViewModel()
			{
				Id = car.Id,
				Mark = car.Mark,
				Model = car.Model,
				Type = car.Type,
				Color = car.Color,
				Passengers = car.Passengers,
				Weight = car.Weight,
				Manual = car.Manual,
				EnginePower = car.EnginePower,
				ReleseDate = car.ReleseDate,
				CreatedAt = car.CreatedAt
			};

			return View(vm);
		}


		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var car = await _carsServices.GetAsync(id);

			if(car  == null)
			{
				return NotFound();
			}

			var vm = new CarDeleteViewModel()
			{
				Id = car.Id,
				Mark = car.Mark,
				Model = car.Model,
				Type = car.Type,
				Color = car.Color,
				Passengers = car.Passengers,
				Weight = car.Weight,
				Manual = car.Manual,
				EnginePower = car.EnginePower,
				ReleseDate = car.ReleseDate,
				CreatedAt = car.CreatedAt
			};

			return View(vm);
		}


	}
}
