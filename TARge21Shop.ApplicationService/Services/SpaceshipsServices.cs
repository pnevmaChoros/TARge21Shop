using TARge21Shop.Data;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain;

namespace TARge21Shop.ApplicationService.Services
{
    public class SpaceshipsServices : ISpaceshipsSevices
    {
        private readonly TARge21ShopContext _context;
        private readonly IFilesServices _files;

        public SpaceshipsServices
            (
                TARge21ShopContext context,
                IFilesServices files
            )
        {
            _context = context;
            _files = files;
        }


        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Crew = dto.Crew;
            spaceship.Passengers = dto.Passengers;
            spaceship.CargoWeight = dto.CargoWeight;
            spaceship.FullTripsCount = dto.FullTripsCount;
            spaceship.MaintenanceCount = dto.MaintenanceCount;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.MaidenLaunch = dto.MaidenLaunch;
            spaceship.BuiltDate = dto.BuiltDate;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            if(dto.Files != null)
            {
                _files.UploadFileToDatabase(dto, spaceship);
            }

            await _context.Spaceships.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Id = dto.Id,
                Name = dto.Name,
                Type = dto.Type,
                Crew = dto.Crew,
                Passengers = dto.Passengers,
                CargoWeight = dto.CargoWeight,
                FullTripsCount = dto.FullTripsCount,
                MaintenanceCount = dto.MaintenanceCount,
                EnginePower = dto.EnginePower,
                MaidenLaunch = dto.MaidenLaunch,
                BuiltDate = dto.BuiltDate,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
                //Files = dto.Files,
                //Images = dto.Images
            };

            if (dto.Files != null)
            {
                _files.UploadFileToDatabase(dto, domain);
            }

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        //public async Task<Spaceship> Update(Guid id)
        //{
        //    var result = await _context.Spaceships
        //        .FirstOrDefaultAsync(x => x.Id == id);

        //    return result;
        //}

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x =>x.Id == id);

            var images = await _context.FileToDatabases
                .Where(x => x.SpaceshipId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    SpaceshipId = y.SpaceshipId,
                })
                .ToArrayAsync();

            await _files.RemoveImageFromDatabase(images);
            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }

        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceships.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}

