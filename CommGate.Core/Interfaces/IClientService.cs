using CommGate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Interfaces
{
    public interface IClientService
    {
        Task<Client> ValidatActiveClientAsync(string clientId);
    }
}
