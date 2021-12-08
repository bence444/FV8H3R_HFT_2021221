using System.Collections.Generic;
using FV8H3R_HFT_2021221.Models;

namespace FV8H3R_HFT_2021221.Logic
{
    public interface ILogic
    {
        Message ReadOne(int id);
        IList<Message> ReadAll();
        void Update(Message updated);
        void Create(Message newMessage);
        void Delete(Message forDelete);
        void Delete(int id);
    }
}
