using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Data;
using Microsoft.AspNetCore.Http;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationService.Services 
{
    public class FilesServices : IFileServices
    {
        private readonly TARge21ShopContext _context;

        public FilesServices
            (
                TARge21ShopContext context
            )
        {
            _context = context;
        }

        public void UploadFileToDatabase(SpaceshipDto dto, Spaceship domain)
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
                            SpaceshipId = domain.Id,
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FileToDatabases.Add(files);
                    }
                }
            }
        }
    }
}
