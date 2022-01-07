using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data
{
    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>();
    }
}
