using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data.Contracts
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string message, string userName);
    }
}
