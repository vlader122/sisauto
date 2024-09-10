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
    public class DetalleOrdenesRepository : IRepository<DetalleOrdenes>
    {
        private readonly SisautoContext _context;
        public DetalleOrdenesRepository(SisautoContext context)
        {
            _context = context;
        }

        public async Task<DetalleOrdenes> Create(DetalleOrdenes entity)
        {
            _context.DetalleOrdenes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<DetalleOrdenes> Delete(int id)
        {
            var entity = await _context.DetalleOrdenes.FindAsync(id);
            if (entity != null)
            {
                _context.DetalleOrdenes.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<List<DetalleOrdenes>> GetAll()
        {
            return await _context.DetalleOrdenes.ToListAsync();
        }

        public async Task<DetalleOrdenes> GetById(int id)
        {
            return await _context.DetalleOrdenes.FindAsync(id);
        }

        public async Task<DetalleOrdenes> Update(DetalleOrdenes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
