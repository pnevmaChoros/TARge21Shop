using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
	public interface IFilesServices
	{
		void UploadPictureToDatabase(CarDto dto, Car domain);
		Task<PictureToDatabase> RemoveImage(PictureToDatabaseDto dto);

		Task<List<PictureToDatabase>> RemoveImageFromDatabase(PictureToDatabaseDto[] dtos);
	}
}
