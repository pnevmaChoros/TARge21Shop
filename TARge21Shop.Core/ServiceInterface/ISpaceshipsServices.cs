using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface ISpaceshipsSevices
    {
        Task<Spaceship> Add(SpaceshipDto dto);

        Task<Spaceship> GetUpdate(Guid id);

        Task<Spaceship> Update(SpaceshipDto dto);

        Task<Spaceship> Delete(Guid id);

        //Task<Spaceship> Details(Guid id);

        Task<Spaceship> GetAsync(Guid id);
    }


}
