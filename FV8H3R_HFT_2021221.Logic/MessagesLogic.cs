using FV8H3R_HFT_2021221.Models;
using FV8H3R_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (newMessage.MessagesSent.Length < 1)
                throw new ArgumentException(nameof(newMessage), "Message length must be at least 1 character");

            msgRepo.Create(newMessage);
        }

        public void Delete(Messages forDelete)
        {
            msgRepo.Delete(forDelete);
        }

        public void Delete(int id)
        {
            msgRepo.Delete(id);
        }

        public IList<Messages> GetAll()
        {
            return msgRepo.GetAll().ToList();
        }

        public Messages GetOne(int id)
        {
            return msgRepo.GetOne(id);
        }

        public void Update(Messages updated)
        {
            msgRepo.Update(updated);
        }

        public double AverageLength()
        {
            return (double)msgRepo.GetAll().Average(x => x.MessagesSent.Length);
        }
    }
}
