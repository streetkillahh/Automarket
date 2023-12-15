using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Profile;
using Automarket.Domain.ViewModels.Car;

namespace Automarket.Service.Interfaces
{
    public interface IProfileService
    {
        Task<BaseResponse<ProfileViewModel>> GetProfile(string userName);
    }
}
