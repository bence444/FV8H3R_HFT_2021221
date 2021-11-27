using FV8H3R_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FV8H3R_HFT_2021221.Repository
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(DbContext ctx) : base(ctx) { }

        public void ChangeBio(int id, string text)
        {
            var user = GetOne(id);

            if (user == null)
                throw new InvalidOperationException("No user found");

            user.Bio = text;

            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            Delete(GetOne(id));
        }

        public override Users GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Update(Users updated)
        {
            var userToUpdate = GetOne(updated.Id);

            userToUpdate.Name = updated.Name;
            userToUpdate.AvailableLikes = updated.AvailableLikes;
            userToUpdate.RegDate = updated.RegDate;
            ctx.SaveChanges();
        }
    }
}
