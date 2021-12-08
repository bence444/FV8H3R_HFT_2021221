using System.Collections.Generic;
using FV8H3R_HFT_2021221.Models;

namespace FV8H3R_HFT_2021221.Logic
{
    public interface ILogic<T>
    {
        T ReadOne(int id);
        IList<T> ReadAll();
        void Update(int id, T updated);
        void Create(T newMessage);
        void Delete(T forDelete);
        void Delete(int id);
    }
}
