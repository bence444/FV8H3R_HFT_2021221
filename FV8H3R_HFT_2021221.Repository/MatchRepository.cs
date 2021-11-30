using FV8H3R_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FV8H3R_HFT_2021221.Repository
{
    public class MatchRepository : IRepository<Matches>
    {
        DbContext ctx;

        public MatchRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Matches entity)
        {
            ctx.Set<Matches>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(Matches entity)
        {
            ctx.Set<Matches>().Remove(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(ReadOne(id));
        }

        public IQueryable<Matches> ReadAll()
        {
            return ctx.Set<Matches>();
        }

        public Matches ReadOne(int id)
        {
            return ReadAll().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Matches updated)
        {
            var matchToUpdate = ReadOne(updated.Id);

            matchToUpdate.Messages = updated.Messages;
            matchToUpdate.DeletedMatch = updated.DeletedMatch;

            ctx.SaveChanges();
        }
    }
}
