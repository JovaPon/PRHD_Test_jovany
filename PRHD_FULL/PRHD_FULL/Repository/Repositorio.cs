using Microsoft.EntityFrameworkCore;
using PRHD_FULL.Data;
using PRHD_FULL.Repository.IRepository;
using System.Linq.Expressions;

namespace PRHD_FULL.Repository
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        //Metodo, se realiza las consultas a las tablas, generico
        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
           
            return await query.ToListAsync();
        }
    }
}
