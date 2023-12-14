using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Profile;
using Automarket.Domain.ViewModels.Car;

namespace Automarket.Service.Interfaces
{
    public interface IProfileService
    {
        Task<IBaseResponse<Profile>> Get(string userName);

        Task<IBaseResponse<Profile>> Create(ProfileViewModel model);

        Task<IBaseResponse<Car>> Edit(long id, ProfileViewModel model);
    }
}
