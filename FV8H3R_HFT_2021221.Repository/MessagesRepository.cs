using FV8H3R_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FV8H3R_HFT_2021221.Repository
{
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
