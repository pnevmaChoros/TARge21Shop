using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Data;
using TARge21Shop.Models.Spaceship;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly ISpaceshipsSevices _spaceshipsSevices;

        public SpaceshipsController
            (
                TARge21ShopContext context,
                ISpaceshipsSevices spaceshipsSevices
            )
        {
            _context = context;
            _spaceshipsSevices = spaceshipsSevices;
        }


        public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Passengers = x.Passengers,
                    EnginePower = x.EnginePower
                });

            return View(result);
        }

        
        [HttpGet]
        public IActionResult Add()
        {
            SpaceshipEditViewModel spaceship = new SpaceshipEditViewModel();

            return View("Edit", spaceship);
        }


        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipEditViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Crew = vm.Crew,
                Passengers = vm.Passengers,
                CargoWeight = vm.CargoWeight,
                FullTripsCount = vm.FullTripsCount,
                MaintenanceCount = vm.MaintenanceCount,
                EnginePower = vm.EnginePower,
                MaidenLaunch = vm.MaidenLaunch,
                BuiltDate = vm.BuiltDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _spaceshipsSevices.Add(dto);

            if(result == null)
            {
                return RedirectToAction(nameof(Index));
            }

                return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipsSevices.GetUpdate(id);

            if(spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipEditViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                Type = spaceship.Type,
                Crew = spaceship.Crew,
                Passengers = spaceship.Passengers,
                CargoWeight = spaceship.CargoWeight,
                FullTripsCount = spaceship.FullTripsCount,
                MaintenanceCount = spaceship.MaintenanceCount,
                EnginePower = spaceship.EnginePower,
                MaidenLaunch = spaceship.MaidenLaunch,
                BuiltDate = spaceship.BuiltDate,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipEditViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Crew = vm.Crew,
                Passengers = vm.Passengers,
                CargoWeight = vm.CargoWeight,
                FullTripsCount = vm.FullTripsCount,
                MaintenanceCount = vm.MaintenanceCount,
                EnginePower = vm.EnginePower,
                MaidenLaunch = vm.MaidenLaunch,
                BuiltDate = vm.BuiltDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _spaceshipsSevices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction(nameof(Index), vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var spaceshipId = await _spaceshipsSevices.Delete(id);

            if (spaceshipId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipsSevices.GetAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDetailsViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                Type = spaceship.Type,
                Crew = spaceship.Crew,
                Passengers = spaceship.Passengers,
                CargoWeight = spaceship.CargoWeight,
                FullTripsCount = spaceship.FullTripsCount,
                MaintenanceCount = spaceship.MaintenanceCount,
                EnginePower = spaceship.EnginePower,
                MaidenLaunch = spaceship.MaidenLaunch,
                BuiltDate = spaceship.BuiltDate,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };

            return View(vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipsSevices.GetAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDeleteViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                Type = spaceship.Type,
                Crew = spaceship.Crew,
                Passengers = spaceship.Passengers,
                CargoWeight = spaceship.CargoWeight,
                FullTripsCount = spaceship.FullTripsCount,
                MaintenanceCount = spaceship.MaintenanceCount,
                EnginePower = spaceship.EnginePower,
                MaidenLaunch = spaceship.MaidenLaunch,
                BuiltDate = spaceship.BuiltDate,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };

            return View(vm);
        }
    }
}
