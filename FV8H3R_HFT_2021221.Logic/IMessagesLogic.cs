using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FV8H3R_HFT_2021221.Models;
using FV8H3R_HFT_2021221.Repository;

namespace FV8H3R_HFT_2021221.Logic
{
    public interface IMessagesLogic
    {
        Messages GetOne(int id);
        IList<Messages> GetAll();
        void Update(Messages updated);
        void Create(Messages newMessage);
        void Delete(Messages forDelete);
        void Delete(int id);
        double AverageLength();
    }
}
