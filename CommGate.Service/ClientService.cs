using CommGate.Core.Entities;
using CommGate.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Service
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryBase<Client> _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientRepository"></param>
        /// <param name="unitOfWork"></param>
        public ClientService(IRepositoryBase<Client> clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Validate the client is active and then return it
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<Client> ValidatActiveClientAsync(string clientId)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
                throw new Exception("ClientNotActive");

            if (client.IsActive == false)
                throw new Exception("ClientNotActive");

            return client;
        }
    }
}
