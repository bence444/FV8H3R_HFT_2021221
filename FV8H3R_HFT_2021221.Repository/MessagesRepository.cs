using FV8H3R_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FV8H3R_HFT_2021221.Repository
{
    public class MessagesRepository : IRepository<Message>
    {
        DbContext ctx;

        public MessagesRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Message entity)
        {
            ctx.Set<Message>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(Message entity)
        {
            ctx.Set<Message>().Remove(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(ReadOne(id));
        }

        public IQueryable<Message> ReadAll()
        {
            return ctx.Set<Message>();
        }

        public Message ReadOne(int id)
        {
            return ReadAll().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Message updated)
        {
            var msgToUpdate = ReadOne(updated.Id);

            msgToUpdate.MessagesSent = updated.MessagesSent;
            msgToUpdate.Deleted = updated.Deleted;

            ctx.SaveChanges();
        }
    }
}
