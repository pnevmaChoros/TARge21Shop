using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
	public interface IFilesServices
	{
		void UploadFileToDatabase(CarDto dto, CarDto domain);
		Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
	}
}
