using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.Domain.Car;
using Microsoft.EntityFrameworkCore;

namespace TARge21Shop.ApplicationService.Services
{
	public class FilesServices : IFilesServices
	{
		private readonly TARge21ShopContext _context;


        public FilesServices
            (
                TARge21ShopContext context
            )
        {
            _context = context;
        }


        public void UploadPictureToDatabase(CarDto dto, Car domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        PictureToDatabase files = new PictureToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            CarId = domain.Id,
                        };

                        photo.CopyTo( target );
                        files.ImageData = target.ToArray();

                        _context.PictureToDatabases.Add( files );
                    }
                }
            }
        }


        public async Task<PictureToDatabase> RemoveImage(PictureToDatabaseDto dto)
        {
            var image = await _context.PictureToDatabases
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            _context.PictureToDatabases.Remove( image );
            await _context.SaveChangesAsync();

            return image;
        }


        public async Task<List<PictureToDatabase>> RemoveImageFromDatabase(PictureToDatabaseDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var image = await _context.PictureToDatabases
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefaultAsync();

                _context.PictureToDatabases.Remove(image);
                await _context.SaveChangesAsync();
            }

            return null;
        }


    }
}
