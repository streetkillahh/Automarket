using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Enum
{
    // Создание перечисляемого типа для сущности Car
    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль")]
        PassengerCar = 0,
        [Display(Name = "Седан")]
        Sedan = 1,
        [Display(Name = "Хэтчбек")]
        HatchBack = 2,
        [Display(Name = "Минивэн")]
        Minivan = 3,
        [Display(Name = "Спортивная машина")]
        SportsCar = 4,
        [Display(Name = "Внедорожник")]
        Suv = 5
    }
}
