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
    public class OrdenesService : IService<Ordenes>
    {
        private readonly OrdenesRepository _ordenesRepository;
        public OrdenesService(OrdenesRepository ordenesRepository)
        {
            _ordenesRepository = ordenesRepository;
        }
        public async Task<Ordenes> Create(Ordenes entity)
        {
            return await _ordenesRepository.Create(entity);
        }

        public async Task<Ordenes> Delete(int id)
        {
            return await _ordenesRepository.Delete(id);
        }

        public async Task<List<Ordenes>> GetAll()
        {
            return await _ordenesRepository.GetAll();
        }

        public async Task<Ordenes> GetById(int id)
        {
            return await _ordenesRepository.GetById(id);
        }

        public async Task<Ordenes> Update(Ordenes entity)
        {
            return await _ordenesRepository.Update(entity);
        }
    }
}
