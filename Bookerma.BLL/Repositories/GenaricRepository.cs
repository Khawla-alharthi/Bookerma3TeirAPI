using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookerma.BLL.Interfaces;
using Bookerma.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookerma.BLL.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;
        public GenaricRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity); 
            await _context.SaveChangesAsync();        
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
