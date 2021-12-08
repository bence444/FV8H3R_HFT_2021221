using System;
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
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Match> Matches { get; set; }

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
            User duri = new User() { Id = 1, Name = "Dorottya", Bio = "van egy kutyám", RegDate = new DateTime(2020, 6, 2) };
            User laci = new User() { Id = 2, Name = "Laszlo", Bio = "", RegDate = new DateTime(2020, 6, 10) };
            User hypy = new User() { Id = 3, Name = "Tamas", Bio = "eszek s*gget", RegDate = new DateTime(2020, 6, 11) };
            User luca = new User() { Id = 4, Name = "Luca", Bio = "", RegDate = new DateTime(2020, 6, 20) };
            User petra = new User() { Id = 5, Name = "Petra", Bio = "anal korrepet keresek", RegDate = new DateTime(2020, 7, 22) };
            User elon = new User() { Id = 6, Name = "Elon Musk", Bio = "im rich", RegDate = new DateTime(2021, 4, 20) };

            Match dl = new Match() { Id = 1, User_1 = duri.Id, User_2 = laci.Id };
            Match hl = new Match() { Id = 2, User_1 = hypy.Id, User_2 = luca.Id, DeletedMatch = true };
            Match hp = new Match() { Id = 3, User_1 = hypy.Id, User_2 = petra.Id };
            Match pe = new Match() { Id = 4, User_1 = petra.Id, User_2 = elon.Id };

            Message dlm = new Message() { Id = 1, MatchId = dl.Id, SenderId = duri.Id, MessagesSent = "szia"};
            Message dlm2 = new Message() { Id = 2, MatchId = dl.Id, SenderId = laci.Id, MessagesSent = "szia date?"};

            Message hlm = new Message() { Id = 3, MatchId = hl.Id, SenderId = hypy.Id, MessagesSent = "szia randi?", Deleted = true };
            Message hlm2 = new Message() { Id = 4, MatchId = hl.Id, SenderId = luca.Id, MessagesSent = "bocsi nem :(", Deleted = true };

            dl.Messages.Add(dlm);
            dl.Messages.Add(dlm2);

            hl.Messages.Add(hlm);
            hl.Messages.Add(hlm2);

            modelBuilder.Entity<User>().HasData(duri, laci, hypy, luca, petra, elon);
            modelBuilder.Entity<Match>().HasData(dl, hl, hp, pe);
            modelBuilder.Entity<Message>().HasData(dlm, hlm);
        }
    }
}
