using FV8H3R_HFT_2021221.Models;
using FV8H3R_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FV8H3R_HFT_2021221.Logic
{
    public class MessagesLogic : IMessagesLogic
    {
        IMessagesRepository msgRepo;

        public MessagesLogic(IMessagesRepository msgRepo)
        {
            this.msgRepo = msgRepo;
        }

        public void Create(Messages newMessage)
        {
            throw new NotImplementedException();
        }

        public void Delete(Messages forDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Messages> GetAll()
        {
            throw new NotImplementedException();
        }

        public Messages GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Messages updated)
        {
            throw new NotImplementedException();
        }

        public double AverageLength()
        {
            throw new NotImplementedException();
        }
    }
}
