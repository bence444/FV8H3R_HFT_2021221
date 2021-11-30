using FV8H3R_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FV8H3R_HFT_2021221.Repository
{
    public class UserRepository : IRepository<Users>
    {
        DbContext ctx;

        public UserRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Users entity)
        {
            ctx.Set<Users>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(Users entity)
        {
            ctx.Set<Users>().Remove(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(ReadOne(id));
        }

        public IQueryable<Users> ReadAll()
        {
            return ctx.Set<Users>();
        }

        public Users ReadOne(int id)
        {
            return ReadAll().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Users updated)
        {
            var userToUpdate = ReadOne(updated.Id);

            userToUpdate.Name = updated.Name;
            userToUpdate.Bio = updated.Bio;
            userToUpdate.AvailableLikes = updated.AvailableLikes;
            
            ctx.SaveChanges();
        }
    }
}
