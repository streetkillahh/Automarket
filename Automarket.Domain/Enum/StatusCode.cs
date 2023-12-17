using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Enum
{
    public enum StatusCode
    {
        EntityNotFound = 400,
        UserAlreadyExists = 300,
        OK = 200,
        InternalServerError = 500
    }
}
