﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FV8H3R_HFT_2021221.Models;

namespace FV8H3R_HFT_2021221.Data
{
    class TinderDbContext : DbContext
    {
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }

        public TinderDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Users duri = new Users() { Id = 1, Name = "Dorottya", Bio = "van egy kutyám", RegDate = new DateTime(2020, 6, 2) };
            Users laci = new Users() { Id = 2, Name = "Laszlo", Bio = "", RegDate = new DateTime(2020, 6, 10) };
            Users hypy = new Users() { Id = 3, Name = "Tamas", Bio = "eszek s*gget", RegDate = new DateTime(2020, 6, 11) };
            Users luca = new Users() { Id = 4, Name = "Luca", Bio = "", RegDate = new DateTime(2020, 6, 20) };
            Users petra = new Users() { Id = 5, Name = "Petra", Bio = "anal korrepet keresek", RegDate = new DateTime(2020, 7, 22) };
            Users elon = new Users() { Id = 6, Name = "Elon Musk", Bio = "im rich", RegDate = new DateTime(2021, 4, 20) };

            Matches dl = new Matches() { Id = 1, User_1 = duri.Id, User_2 = laci.Id };
            Matches hl = new Matches() { Id = 2, User_1 = hypy.Id, User_2 = luca.Id };
            Matches hp = new Matches() { Id = 3, User_1 = hypy.Id, User_2 = petra.Id };
            Matches pe = new Matches() { Id = 4, User_1 = petra.Id, User_2 = elon.Id };

            Messages dlm = new Messages() { Id = 1, MatchId = dl.Id, SenderId = duri.Id, MessagesSent = "szia", Deleted = false};
            Messages dlm2 = new Messages() { Id = 2, MatchId = dl.Id, SenderId = laci.Id, MessagesSent = "szia date?", Deleted = false };

            Messages hlm = new Messages() { Id = 3, MatchId = hl.Id, SenderId = hypy.Id, MessagesSent = "szia randi?", Deleted = true };
            Messages hlm2 = new Messages() { Id = 4, MatchId = hl.Id, SenderId = luca.Id, MessagesSent = "bocsi nem :(", Deleted = true };

            dl.Messages.Add(dlm);
            dl.Messages.Add(dlm2);

            hl.Messages.Add(hlm);
            hl.Messages.Add(hlm2);

            modelBuilder.Entity<Users>().HasData(duri, laci, hypy, luca, petra, elon);
            modelBuilder.Entity<Matches>().HasData(dl, hl, hp, pe);
            modelBuilder.Entity<Messages>().HasData(dlm, hlm);
        }
    }
}