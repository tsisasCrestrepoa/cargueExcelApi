using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PruebaCargueExcel;

namespace DataAccess.Repository
{
    public class GenericEntity<TEntity>where TEntity : class
    {
        private readonly PruebaCargueExcelContext context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericEntity(PruebaCargueExcelContext _context)
        {
            context = _context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Insertar(TEntity entidad)
        {
            await _dbSet.AddAsync(entidad);
            await context.SaveChangesAsync();
        }
    }
}
