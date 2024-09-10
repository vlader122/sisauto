using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrdenesRepository : IRepository<Ordenes>
    {
        private readonly SisautoContext _context;
        public OrdenesRepository(SisautoContext context)
        {
            _context = context;
        }

        public async Task<Ordenes> Create(Ordenes entity)
        {
            _context.Ordenes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Ordenes> Delete(int id)
        {
            var entity = await _context.Ordenes.FindAsync(id);
            if (entity != null)
            {
                _context.Ordenes.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<List<Ordenes>> GetAll()
        {
            return await _context.Ordenes.ToListAsync();
        }

        public async Task<Ordenes> GetById(int id)
        {
            var orden = await _context.Ordenes
                .Include(c => c.DetalleOrdenes)
                    .ThenInclude(d => d.Servicio)
                .Include(c => c.Cliente)
                .Where(o=>o.OrdenID == id)
                .FirstOrDefaultAsync();
            return orden;
        }

        public async Task<Ordenes> Update(Ordenes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
