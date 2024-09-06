using DB.Models;
using Repository;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiciosService : IService<Servicios>
    {
        private readonly ServiciosRepository _clientesRepository;
        public ServiciosService(ServiciosRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }
        public async Task<Servicios> Create(Servicios entity)
        {
            return await _clientesRepository.Create(entity);
        }

        public async Task<Servicios> Delete(int id)
        {
            return await _clientesRepository.Delete(id);
        }

        public async Task<List<Servicios>> GetAll()
        {
            return await _clientesRepository.GetAll();
        }

        public async Task<Servicios> GetById(int id)
        {
            return await _clientesRepository.GetById(id);
        }

        public async Task<Servicios> Update(Servicios entity)
        {
            return await _clientesRepository.Update(entity);
        }
    }
}
