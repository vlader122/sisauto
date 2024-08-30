using DB;
using DB.Models;
using Repository.interfaces;

namespace Repository
{
    public class PaisesRepository : IRepository<Paises>
    {
        private readonly SisautoContext _context;
        public PaisesRepository(SisautoContext context)
        {
            _context = context;
        }
        public void Create(Paises entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Paises> GetAll()
        {
            List<Paises> paises = _context.Paises.ToList();
            return paises;
        }

        public Paises GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Paises entity)
        {
            throw new NotImplementedException();
        }
    }
}
