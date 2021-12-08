using FV8H3R_HFT_2021221.Models;
using FV8H3R_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FV8H3R_HFT_2021221.Logic
{
    public class MatchLogic : ILogic<Match>
    {
        IRepository<Match> matchRepo;

        public MatchLogic(IRepository<Match> matchRepo)
        {
            this.matchRepo = matchRepo;
        }

        public void Create(Match newMessage)
        {
            throw new NotImplementedException();
        }

        public void Delete(Match forDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Match> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Match ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Match updated)
        {
            throw new NotImplementedException();
        }
    }
}
