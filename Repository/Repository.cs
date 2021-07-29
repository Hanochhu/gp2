using gp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Gp2Context _gp2Context;

        private DbSet<T> _entity;

        public Repository(Gp2Context gp2Context)
        {
            _gp2Context = gp2Context;
        }

        private DbSet<T> Entity => _entity ?? (_entity = _gp2Context.Set<T>());

        public void Add(T t)
        {
            Entity.Add(t);
            _gp2Context.SaveChanges();

        }

        public void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            return Entity.Find(id);
        }

        public async Task<T> FindAsync(int id)
        {

            return await Entity.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Entity.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T t)
        {
            Entity.Update(t);
            await _gp2Context.SaveChangesAsync();
            return;
        }

      
    }
}
