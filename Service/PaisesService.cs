using DB;
using DB.Models;
using Repository;

namespace Service
{
    public class PaisesService
    {
        private readonly PaisesRepository _paisesRepository;
        public PaisesService(PaisesRepository paisesRepository)
        {
            _paisesRepository = paisesRepository;
        }
        public List<Paises> GetAll()
        {
            return _paisesRepository.GetAll();
        }
    }
}
