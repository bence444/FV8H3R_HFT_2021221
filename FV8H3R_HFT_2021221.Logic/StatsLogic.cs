using FV8H3R_HFT_2021221.Models;
using FV8H3R_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FV8H3R_HFT_2021221.Logic
{
    public class StatsLogic
    {
        IRepository<User> userRepo;
        IRepository<Match> matchRepo;
        IRepository<Message> msgRepo;

        public StatsLogic(IRepository<User> userRepo, IRepository<Match> matchRepo, IRepository<Message> msgRepo)
        {
            this.userRepo = userRepo;
            this.matchRepo = matchRepo;
            this.msgRepo = msgRepo;
        }

        public IEnumerable<User> UsersWithDeletedMatch()
        {
            var ur = from user in userRepo.ReadAll()
                     join match in matchRepo.ReadAll() on user.Id equals match.User_1
                     join match2 in matchRepo.ReadAll() on user.Id equals match2.User_2
                     where match.DeletedMatch || match2.DeletedMatch
                     select user;

            return ur;
        }

        public IQueryable MostMsgSentByUser()
        {
            var um = from user in userRepo.ReadAll()
                     join msg in msgRepo.ReadAll() on user.Id equals msg.SenderId
                     group user by user.Name into u
                     select new { Name = u.Key, Count = u.Key.Count() };

            return um;
        }

        public IEnumerable<Match> MostMsgSentToMatch()
        {
            var mm = (from match in matchRepo.ReadAll()
                     join msg in msgRepo.ReadAll() on match.Id equals msg.MatchId
                     group match by match.Id into m
                     orderby m.Count()
                     select m).First();

            return mm;
        }

        public IEnumerable<Message> MessageOf(string name)
        {
            var mo = from msg in msgRepo.ReadAll()
                     join user in userRepo.ReadAll() on msg.SenderId equals user.Id
                     where user.Name.Contains(name)
                     select msg;

            return mo;
        }

        public IEnumerable<User> UsersWithTrustIssues()
        {
            var to = from user in userRepo.ReadAll()
                     join msg in msgRepo.ReadAll() on user.Id equals msg.SenderId
                     where msg.Deleted
                     select user;

            return to;
        }
    }
}
