using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARge21Shop.ApplicationService.Services;   
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.RealEstate;

namespace TARge21Shop.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstatesServices;
        private readonly TARge21ShopContext _context;
        private readonly IFilesServices _filesServices;

        public RealEstatesController
            (
            IRealEstatesServices realEstatesServices,
            TARge21ShopContext context,
            IFilesServices filesServices
            )
        {
            _realEstatesServices = realEstatesServices;
            _context = context;
            _filesServices = filesServices;
    }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var result = _context.RealEstates
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    Size = x.Size,
                    Price = x.Price,
                });

            return View(result);
            //var realEstate = await _realEstates.GetAsync(id);

            //if(realEstate == null)
            //{
            //    return NotFound();
            //}

            //var vm = new RealEstateIndexViewModel(); //vm = view model

            //vm.Id = id;
            //vm.Address = realEstate.Address;
            //vm.City = realEstate.City;
            //vm.Region = realEstate.Region;
            //vm.PostalCode = realEstate.PostalCode;
            //vm.Country = realEstate.Country;
            //vm.Phone = realEstate.Phone;
            //vm.Fax = realEstate.Fax;
            //vm.Size = realEstate.Size;
            //vm.Floor = realEstate.Floor;
            //vm.Price = realEstate.Price;
            //vm.RoomCounter = realEstate.RoomCounter;
            //vm.CreatedAt = realEstate.CreatedAt;
            //vm.ModifiedAt = realEstate.ModifiedAt;


        }


        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel vm = new();

            return View("CreateUpdate", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Region = vm.Region,
                PostalCode = vm.PostalCode,
                Country = vm.Country,
                Size = vm.Size,
                Phone = vm.Phone,
                Price = vm.Price,
                Floor = vm.Floor,
                Fax = vm.Fax,
                RoomCounter = vm.RoomCounter,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                FileToApiDtos = vm.FileToApiViewModels.Select(x => new FileToApiDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    RealEstateId = x.RealEstateId
                }).ToArray()
            };

            var result = await _realEstatesServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", vm);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new RealEstateDetailsViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.Region = realEstate.Region;
            vm.PostalCode = realEstate.PostalCode;
            vm.Country = realEstate.Country;
            vm.Size = realEstate.Size;
            vm.Phone = realEstate.Phone;
            vm.Price = realEstate.Price;
            vm.Floor = realEstate.Floor;
            vm.Fax = realEstate.Fax;
            vm.RoomCounter = realEstate.RoomCounter;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.FileToApiViewModels.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            

            if (realEstate == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();


            var vm = new RealEstateDeleteViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.Region = realEstate.Region;
            vm.PostalCode = realEstate.PostalCode;
            vm.Country = realEstate.Country;
            vm.Size = realEstate.Size;
            vm.Phone = realEstate.Phone;
            vm.Price = realEstate.Price;
            vm.Floor = realEstate.Floor;
            vm.Fax = realEstate.Fax;
            vm.RoomCounter = realEstate.RoomCounter;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.FileToApiViewModels.AddRange(images);

            return View(vm);

        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realEstate = await _realEstatesServices.Delete(id);

            if (realEstate == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> RemoveImage(FileToApiViewModel vm)
        {
            var dto = new FileToApiDto()
            {
                Id = vm.ImageId,
            };

            var image = await _filesServices.RemoveImageFromApi(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            if(realEstate == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new RealEstateCreateUpdateViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.Region = realEstate.Region;
            vm.PostalCode = realEstate.PostalCode;
            vm.Country = realEstate.Country;
            vm.Size = realEstate.Size;
            vm.Phone = realEstate.Phone;
            vm.Price = realEstate.Price;
            vm.Floor = realEstate.Floor;
            vm.Fax = realEstate.Fax;
            vm.RoomCounter = realEstate.RoomCounter;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.FileToApiViewModels.AddRange(images);

            return View("CreateUpdate", vm);

        }


        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Region = vm.Region,
                PostalCode = vm.PostalCode,
                Country = vm.Country,
                Phone = vm.Phone,
                Fax = vm.Fax,
                Size = vm.Size,
                Price = vm.Price,
                Floor = vm.Floor,
                RoomCounter = vm.RoomCounter,
                Files = vm.Files,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                FileToApiDtos = vm.FileToApiViewModels
                    .Select(x => new FileToApiDto
                    {
                        Id = x.ImageId,
                        ExistingFilePath = x.FilePath,
                        RealEstateId = x.RealEstateId,
                    }).ToArray(),
            };

            var result = await _realEstatesServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

    }
}
