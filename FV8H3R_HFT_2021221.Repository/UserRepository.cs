using FV8H3R_HFT_2021221.Data;
using FV8H3R_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FV8H3R_HFT_2021221.Repository
{
    public class UserRepository : IRepository<User>, IUserRepository
    {
        TinderDbContext ctx;

        public UserRepository(TinderDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(User entity)
        {
            ctx.Set<User>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(User entity)
        {
            ctx.Set<User>().Remove(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(ReadOne(id));
            ctx.SaveChanges();
        }

        public IQueryable<User> ReadAll()
        {
            return ctx.Set<User>();
        }

        public User ReadOne(int id)
        {
            return ReadAll().FirstOrDefault(x => x.Id == id);
        }


        public void Update(User updated)
        {
            var userToUpdate = ReadOne(updated.Id);

            userToUpdate.Name = updated.Name;
            userToUpdate.Bio = updated.Bio;
            userToUpdate.AvailableLikes = updated.AvailableLikes;
            
            ctx.SaveChanges();
        }

        public void RefreshLikes()
        {
            throw new NotImplementedException();
        }

        public void ChangeBio(string text)
        {
            throw new NotImplementedException();
        }

        public void ChangeName(string text)
        {
            throw new NotImplementedException();
        }
    }
}
