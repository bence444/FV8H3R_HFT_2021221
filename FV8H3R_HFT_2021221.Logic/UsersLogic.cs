using FV8H3R_HFT_2021221.Models;
using FV8H3R_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FV8H3R_HFT_2021221.Logic
{
    class UsersLogic : ILogic
    {
        IRepository<User> userRepo;

        public UsersLogic(IRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        public void Create(User newUser)
        {
            if (newUser.Name.Length < 1)
                throw new ArgumentException(nameof(newUser), "Message length must be at least 1 character");

            userRepo.Create(newUser);
        }

        public void Delete(User forDelete)
        {
            userRepo.Delete(forDelete);
        }

        public void Delete(int id)
        {
            userRepo.Delete(id);
        }

        public IList<User> ReadAll()
        {
            return userRepo.ReadAll().ToList();
        }

        public User ReadOne(int id)
        {
            return userRepo.ReadOne(id);
        }

        public void Update(User updated)
        {
            userRepo.Update(updated);
        }
    }
}
