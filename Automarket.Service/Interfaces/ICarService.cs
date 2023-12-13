using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();

        Task<IBaseResponse<CarViewModel>> GetCar(int id);

        Task<IBaseResponse<Car>> Create(CarViewModel car, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteCar(int id);

        Task<IBaseResponse<Car>> GetCarByName(string name);

        Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
    }
}
