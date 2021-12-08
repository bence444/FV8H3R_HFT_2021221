using FV8H3R_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FV8H3R_HFT_2021221.Repository
{
    public interface IMessageRepository : IRepository<Message>
    {
        void UnsendMsg(Message msg);
        void SendMsg(string text, int matchId, int U1, int U2);
    }
}
