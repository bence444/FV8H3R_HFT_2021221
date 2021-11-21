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

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract void Delete(int id);
        public abstract T GetOne(int id);
        public abstract void Update(T updated);
    }

    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(DbContext ctx) : base(ctx) { }

        public void ChangeBio(int id, string text)
        {
            var user = GetOne(id);

            if (user == null)
                throw new InvalidOperationException("No user found");

            user.Bio = text;

            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            Delete(GetOne(id));
        }

        public override Users GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Update(Users updated)
        {
            var userToUpdate = GetOne(updated.Id);

            userToUpdate.Name = updated.Name;
            userToUpdate.AvailableLikes = updated.AvailableLikes;
            userToUpdate.RegDate = updated.RegDate;
            ctx.SaveChanges();
        }
    }

    public class MessagesRepository : Repository<Messages>, IMessagesRepository
    {
        public MessagesRepository(DbContext ctx) : base(ctx) { }

        public void UnsendMessage(int id)
        {
            var msg = GetOne(id);

            if (msg == null)
                throw new InvalidOperationException("Not found");

            msg.Deleted = true;
            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            ctx.Set<Messages>().Remove(GetOne(id));
            ctx.SaveChanges();
        }

        public override Messages GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Update(Messages updated)
        {
            var msgToUpdate = GetOne(updated.Id);

            msgToUpdate.MessagesSent = updated.MessagesSent;
            ctx.SaveChanges();
        }
    }
}
