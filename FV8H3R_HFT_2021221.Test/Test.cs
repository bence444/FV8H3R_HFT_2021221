using FV8H3R_HFT_2021221.Logic;
using FV8H3R_HFT_2021221.Models;
using FV8H3R_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FV8H3R_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        Mock<IRepository<Models.Match>> matchRepo = new Mock<IRepository<Models.Match>>();
        Mock<IRepository<User>> userRepo = new Mock<IRepository<User>>();
        Mock<IRepository<Message>> msgRepo = new Mock<IRepository<Message>>();

        /* MatchLogic matchLog;
        UserLogic userLog;
        MessageLogic msgLog; */

        /* static User newUser = new User() { Id = 1, Name = "Teszt Elek", AvailableLikes = 10, Bio = "mom pick me up im scared", RegDate = DateTime.MinValue };
        static User newUser2 = new User() { Id = 2, Name = "Aleska Diamond", AvailableLikes = 100, Bio = "onlyfans", RegDate = DateTime.Today };

        static Models.Match newMatch = new Models.Match() { Id = 1, User_1 = newUser.Id, User_2 = newUser2.Id, DeletedMatch = false };

        static Message newMsg = new Message() { Id = 1, MatchId = newMatch.Id, MessagesSent = "hi show foot plz", Deleted = true }; */

        [Test]
        public void AddTest()
        {
            userRepo.Setup(x => x.Create(It.IsAny<User>()));

            UserLogic userLog = new UserLogic(userRepo.Object);
            userLog.Create(new User() { Name = "Teszt Elek", Bio = "haha"});

            userRepo.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void DeleteTest()
        {
            msgRepo.Setup(x => x.Delete(It.IsAny<int>()));

            MessageLogic msgLog = new MessageLogic(msgRepo.Object);
            msgLog.Delete(1);

            msgRepo.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ReadAllTest()
        {
            List<Message> msgList = new List<Message>()
            {
                new Message() { Id = 1, MessagesSent = "henlo", SenderId = 1},
                new Message() { Id = 2, MessagesSent = "pls", SenderId = 1},
                new Message() { Id = 3, MessagesSent = "hii", SenderId = 2}
            };

            msgRepo.Setup(x => x.ReadAll()).Returns(msgList.AsQueryable());
        }

        [Test]
        public void ReadOneTest()
        {
            msgRepo.Setup(x => x.ReadOne(It.IsAny<int>())).Returns( new Message() { Id = 1, MessagesSent = "kekw" });

            MessageLogic msgLog = new MessageLogic(msgRepo.Object);

            Message result = msgLog.ReadOne(1);
            Assert.That(result.Id, Is.EqualTo(1));

            msgRepo.Verify(x => x.ReadOne(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void UpdateUserTest()
        {
            userRepo.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<User>()));

            UserLogic userLog = new UserLogic(userRepo.Object);

            List<User> users = new List<User>()
            {
                new User() { Id = 1, Name = "Teszt Elek", Bio = "haha" },
                new User() { Id = 2, Name = "Joseph Sayer", Bio = "" }
            };

            users[1].Bio = "no no no";
            userLog.Update(users[1].Id, users[1]);

            userRepo.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<User>()));
        }

        [Test]
        public void UsersWithDeletedMatch()
        {
            List<User> users = new List<User>()
            {
                new User() { Id = 1, Name = "Teszt Elek", Bio = "haha" },
                new User() { Id = 2, Name = "Joseph Sayer", Bio = "" },
                new User() { Id = 3, Name = "Krubi Banán", Bio = "banán" },
                new User() { Id = 4, Name = "Palvin Barbi", Bio = "" }
            };

            List<Models.Match> matches = new List<Models.Match>()
            {
                new Models.Match() { Id = 1, User_1 = users[2].Id, User_2 = users[3].Id, DeletedMatch = true },
                new Models.Match() { Id = 2, User_1 = users[0].Id, User_2 = users[1].Id, DeletedMatch = false },
                new Models.Match() { Id = 3, User_1 = users[0].Id, User_2 = users[3].Id, DeletedMatch = false }
            };

            List<User> expected = new List<User>() { users[2], users[3] };

            userRepo.Setup(x => x.ReadAll()).Returns(users.AsQueryable());
            matchRepo.Setup(x => x.ReadAll()).Returns(matches.AsQueryable());

            StatsLogic logic = new StatsLogic(userRepo.Object, matchRepo.Object, msgRepo.Object);

            var results = logic.UsersWithDeletedMatch();

            Assert.That(results, Is.EquivalentTo(expected));

            userRepo.Verify(x => x.ReadAll(), Times.AtLeastOnce);
            matchRepo.Verify(x => x.ReadAll(), Times.AtLeastOnce);
        }

        [Test]
        public void MostMsgSentByUser()
        {
            List<User> users = new List<User>()
            {
                new User() { Id = 1, Name = "Teszt Elek", Bio = "haha" },
                new User() { Id = 2, Name = "Joseph Sayer", Bio = "" },
                new User() { Id = 3, Name = "Krubi Banán", Bio = "banán" },
                new User() { Id = 4, Name = "Palvin Barbi", Bio = "" }
            };

            List<Message> messages = new List<Message>()
            {
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[1].Id },
                new Message() { SenderId = users[2].Id },
                new Message() { SenderId = users[2].Id },
            };

            List<User> expected = new List<User>() { users[0], users[2], users[1] };

            userRepo.Setup(x => x.ReadAll()).Returns(users.AsQueryable());
            msgRepo.Setup(x => x.ReadAll()).Returns(messages.AsQueryable());

            StatsLogic logic = new StatsLogic(userRepo.Object, matchRepo.Object, msgRepo.Object);

            var results = logic.MostMsgSentByUser();

            Assert.That(results, Is.EquivalentTo(expected));

            userRepo.Verify(x => x.ReadAll(), Times.AtLeastOnce);
            msgRepo.Verify(x => x.ReadAll(), Times.AtLeastOnce);
        }

        [Test]
        public void MessageOf()
        {
            List<User> users = new List<User>()
            {
                new User() { Id = 1, Name = "Teszt Elek", Bio = "haha" },
                new User() { Id = 2, Name = "Joseph Sayer", Bio = "" },
                new User() { Id = 3, Name = "Krubi Banán", Bio = "banán" },
                new User() { Id = 4, Name = "Palvin Barbi", Bio = "" }
            };

            List<Message> messages = new List<Message>()
            {
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[1].Id },
                new Message() { SenderId = users[2].Id },
                new Message() { SenderId = users[2].Id },
            };

            List<Message> expected = new List<Message>() { messages[6], messages[7] };

            userRepo.Setup(x => x.ReadAll()).Returns(users.AsQueryable());
            msgRepo.Setup(x => x.ReadAll()).Returns(messages.AsQueryable());

            StatsLogic logic = new StatsLogic(userRepo.Object, matchRepo.Object, msgRepo.Object);

            var results = logic.MessageOf("Banán");

            Assert.That(results, Is.EquivalentTo(expected));

            userRepo.Verify(x => x.ReadAll(), Times.AtLeastOnce);
            msgRepo.Verify(x => x.ReadAll(), Times.AtLeastOnce);
        }

        [Test]
        public void UsersWithTrustIssues()
        {
            List<User> users = new List<User>()
            {
                new User() { Id = 1, Name = "Teszt Elek", Bio = "haha" },
                new User() { Id = 2, Name = "Joseph Sayer", Bio = "" },
                new User() { Id = 3, Name = "Krubi Banán", Bio = "banán" },
            };

            List<Message> messages = new List<Message>()
            {
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id },
                new Message() { SenderId = users[0].Id, Deleted = true },
                new Message() { SenderId = users[0].Id, Deleted = true },
                new Message() { SenderId = users[1].Id },
                new Message() { SenderId = users[2].Id },
                new Message() { SenderId = users[2].Id },
            };

            List<User> expected = new List<User>() { users[0] };

            userRepo.Setup(x => x.ReadAll()).Returns(users.AsQueryable());
            msgRepo.Setup(x => x.ReadAll()).Returns(messages.AsQueryable());

            StatsLogic logic = new StatsLogic(userRepo.Object, matchRepo.Object, msgRepo.Object);

            var results = logic.UsersWithTrustIssues();

            Assert.That(results, Is.EquivalentTo(expected));

            userRepo.Verify(x => x.ReadAll(), Times.AtLeastOnce);
            msgRepo.Verify(x => x.ReadAll(), Times.AtLeastOnce);
        }
    }
}