using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data
{
    public interface IRolesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
