using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FV8H3R_HFT_2021221.Models;

namespace FV8H3R_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();
        }

        public IQueryable<T> Read()
        {
            return ctx.Set<T>();
        }

        public abstract void Delete(int id);
        public abstract T GetOne(int id);
        public abstract void Update(T updated);
    }
}
