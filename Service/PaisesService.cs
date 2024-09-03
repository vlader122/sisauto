using DB;
using DB.Models;
using Repository;
using Service.interfaces;

namespace Service
{
    public class PaisesService : IService<Paises>
    {
        private readonly PaisesRepository _paisesRepository;
        public PaisesService(PaisesRepository paisesRepository)
        {
            _paisesRepository = paisesRepository;
        }

        public async Task<Paises> Create(Paises entity)
        {
            return await _paisesRepository.Create(entity);
        }

        public async Task<Paises> Delete(int id)
        {
            return await _paisesRepository.Delete(id);
        }

        public async Task<List<Paises>> GetAll()
        {
            return await _paisesRepository.GetAll();
        }

        public async Task<Paises> GetById(int id)
        {
            return await _paisesRepository.GetById(id);
        }

        public async Task<Paises> Update(Paises entity)
        {
            return await _paisesRepository.Update(entity);
        }
    }
}
