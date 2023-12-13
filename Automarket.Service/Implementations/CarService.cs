﻿using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly IBaseRepository<Car> _carRepository;

        public CarService(IBaseRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<CarViewModel>> GetCar(int id)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<CarViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.EntityNotFound
                    };
                }

                var data = new CarViewModel()
                {
                    DateCreate = car.DateCreate,
                    Description = car.Description,
                    TypeCar = car.TypeCar.ToString(),
                    Speed = car.Speed,
                    Model = car.Model,
                    Image = car.Avatar,
                };

                return new BaseResponse<CarViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Create(CarViewModel model, byte[] imageData)
        {
            try
            {
                var car = new Car()
                {
                    Name = model.Name,
                    Model = model.Model,
                    Description = model.Description,
                    DateCreate = DateTime.Now,
                    Speed = model.Speed,
                    TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar),
                    Price = model.Price,
                    Avatar = imageData
                };
                await _carRepository.Create(car);

                return new BaseResponse<Car>()
                {
                    StatusCode = StatusCode.OK,
                    Data = car
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Entity not found",
                        StatusCode = StatusCode.EntityNotFound,
                        Data = false
                    };
                }

                await _carRepository.Delete(car);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
                if (car == null)
                {
                    return new BaseResponse<Car>()
                    {
                        Description = "Entity not found",
                        StatusCode = StatusCode.EntityNotFound
                    };
                }

                return new BaseResponse<Car>()
                {
                    Data = car,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel model)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<Car>()
                    {
                        Description = "Entity not found",
                        StatusCode = StatusCode.EntityNotFound
                    };
                }

                car.Description = model.Description;
                car.Model = model.Model;
                car.Price = model.Price;
                car.Speed = model.Speed;
                car.DateCreate = model.DateCreate;
                car.Name = model.Name;

                await _carRepository.Update(car);


                return new BaseResponse<Car>()
                {
                    Data = car,
                    StatusCode = StatusCode.OK,
                };
                // TypeCar
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
        {
            try
            {
                var cars = _carRepository.GetAll();
                if (!cars.Any())
                {
                    return new BaseResponse<IEnumerable<Car>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<IEnumerable<Car>>()
                {
                    Data = cars,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}