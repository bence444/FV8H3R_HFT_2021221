﻿using FV8H3R_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FV8H3R_HFT_2021221.Repository
{
    public class MatchRepository : IRepository<Match>
    {
        DbContext ctx;

        public MatchRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Match entity)
        {
            ctx.Set<Match>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(Match entity)
        {
            ctx.Set<Match>().Remove(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(ReadOne(id));
        }

        public IQueryable<Match> ReadAll()
        {
            return ctx.Set<Match>();
        }

        public Match ReadOne(int id)
        {
            return ReadAll().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Match updated)
        {
            var matchToUpdate = ReadOne(updated.Id);

            matchToUpdate.Messages = updated.Messages;
            matchToUpdate.DeletedMatch = updated.DeletedMatch;

            ctx.SaveChanges();
        }
    }
}
