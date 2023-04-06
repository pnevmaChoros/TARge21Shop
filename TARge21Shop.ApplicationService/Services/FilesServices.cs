using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using Microsoft.AspNetCore.Hosting;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.Domain.Car;
using Microsoft.EntityFrameworkCore;

namespace TARge21Shop.ApplicationService.Services
{
	public class FilesServices : IFilesServices
	{
		private readonly TARge21ShopContext _context;
		private readonly IHostingEnvironment _webHost;


        public FilesServices
            (
                TARge21ShopContext context,
                IHostingEnvironment webHost
            )
        {
            _context = context;
            _webHost = webHost;
        }


        public void UploadFileToDatabase(CarDto dto, CarDto domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            CarId = domain.Id,
                        };

                        photo.CopyTo( target );
                        files.ImageData = target.ToArray();

                        _context.FileToDatabases.Add( files );
                    }
                }
            }
        }


        public async Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto)
        {
            var image = await _context.FileToDatabases
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            _context.FileToDatabases.Remove( image );
            await _context.SaveChangesAsync();

            return image;
        }


    }
}
