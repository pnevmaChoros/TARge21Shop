using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		private readonly IFilesServices _filesServices;


		public CarsController
			(
				TARge21ShopContext context,
				ICarsServices carsServices,
				IFilesServices filesServices
			)
		{
			_context = context;
			_carsServices = carsServices;
			_filesServices = filesServices;
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
				CreatedAt = vm.CreatedAt,
				Files = vm.Files,
				Image = vm.Images.Select(x => new PictureToDatabaseDto
				{
					Id = x.ImageId,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					CarId = x.CarId,
				}).ToArray()
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
			var car = await _carsServices.GetAsync(id);

			if(car == null)
			{
				return NotFound();
			}

			var photos = await _context.PictureToDatabases
				.Where(x => x.CarId == id)
				.Select(y => new ImageViewModel
				{
					CarId = y.Id,
					ImageId = y.Id,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
				}).ToArrayAsync();

			var vm = new CarEditViewModel();

			vm.Id = car.Id;
			vm.Mark = car.Mark;
			vm.Model = car.Model;
			vm.Type = car.Type;
			vm.Color = car.Color;
			vm.Passengers = car.Passengers;
			vm.Weight = car.Weight;
			vm.Manual = car.Manual;
			vm.EnginePower = car.EnginePower;
			vm.ReleseDate = car.ReleseDate;
			vm.CreatedAt = car.CreatedAt;
			vm.Images.AddRange(photos);

			return View("Edit", vm);
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
				CreatedAt = vm.CreatedAt,
				Files = vm.Files,
				Image = vm.Images.Select(x => new PictureToDatabaseDto
				{
					Id = x.ImageId,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					CarId = x.CarId,
				}).ToArray()
			};

			var result = await _carsServices.Update(dto);

			if(result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}



		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var car = await _carsServices.GetAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			var photos = await _context.PictureToDatabases
				.Where(x => x.CarId == id)
				.Select(y => new ImageViewModel
				{
					CarId = y.CarId,
					ImageId = y.Id,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();


			var vm = new CarDetailsViewModel();

			vm.Id = car.Id;
			vm.Mark = car.Mark;
			vm.Model = car.Model;
			vm.Type = car.Type;
			vm.Color = car.Color;
			vm.Passengers = car.Passengers;
			vm.Weight = car.Weight;
			vm.Manual = car.Manual;
			vm.EnginePower = car.EnginePower;
			vm.ReleseDate = car.ReleseDate;
			vm.CreatedAt = car.CreatedAt;
			vm.Images.AddRange(photos);

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

			var photos = await _context.PictureToDatabases
				.Where(x => x.CarId == id)
				.Select(y => new ImageViewModel
				{
					CarId = y.Id,
					ImageId = y.Id,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
				}).ToArrayAsync();

			var vm = new CarDeleteViewModel();

			vm.Id = car.Id;
			vm.Mark = car.Mark;
			vm.Model = car.Model;
			vm.Type = car.Type;
			vm.Color = car.Color;
			vm.Passengers = car.Passengers;
			vm.Weight = car.Weight;
			vm.Manual = car.Manual;
			vm.EnginePower = car.EnginePower;
			vm.ReleseDate = car.ReleseDate;
			vm.CreatedAt = car.CreatedAt;
			vm.Images.AddRange(photos);

			return View(vm);
		}


		[HttpPost]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var carId = await _carsServices.Delete(id);

			if (carId == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}


		[HttpPost]
		public async Task<IActionResult> RemoveImage(ImageViewModel file)
		{
			var dto = new PictureToDatabaseDto()
			{
				Id = file.ImageId
			};

			var image = await _filesServices.RemoveImage(dto);

			if(image == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}


	}
}
