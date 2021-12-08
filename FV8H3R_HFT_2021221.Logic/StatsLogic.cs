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
    }
}
