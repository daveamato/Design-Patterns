using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            IChatMediator chatMediator = new ChatMediator();

            User user1 = new ChatUser(chatMediator)
            {
                Name = "David",
                UserName = "damato"
            };

            User user2 = new ChatUser(chatMediator)
            {
                Name = "Gary",
                UserName = "gforshee"
            };


            User bot1 = new ChatBot(chatMediator)
            {
                Name = "Bot",
                UserName = "bot"
            };

            chatMediator.AddUser(user1);
            chatMediator.AddUser(user2);
            chatMediator.AddUser(bot1);

            user1.SendMessage("Hi?", user2.UserName);
            user2.SendMessage("Are you all right?", user1.UserName);
            bot1.SendMessage("Let's watch the speeches.", user1.UserName);
            user1.SendMessage("Thanks.", bot1.UserName);

            Console.Read();
        }
    }

    public interface IChatMediator
    {
        void SendMessage(string message, string userName);
        void AddUser(User user);
    }

    public class ChatMediator : IChatMediator
    {
        private readonly Dictionary<string, User> _user;

        public ChatMediator()
        {
            _user = new Dictionary<string, User>();
        }

        public void AddUser(User user)
        {
            _user.Add(user.UserName, user);
        }

        public void SendMessage(string message, string userName)
        {
            User user = _user[userName];
            user.ReceiveMessage(message); //message received, transmitted by the center.
        }
    }

    public abstract class User
    {
        public string UserName { get; set; }
        public string Name { get; set; }

        private readonly IChatMediator _chatMediator;

        public User(IChatMediator chatMediator)
        {
            _chatMediator = chatMediator;
        }

        //The method by which the mediator type will be called.
        public virtual void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name}: {message} -received-");
        }

        //the call is being made towards the object reference of the mediator type.
        public void SendMessage(string message, string userName)
        {
            Console.WriteLine($"{Name}: {message} -sent to {userName}-");
            _chatMediator.SendMessage(message, userName);
        }
    }

    public class ChatUser : User
    {
        public ChatUser(IChatMediator chatMediator) : base(chatMediator)
        {
        }
    }

    public class ChatBot : User
    {
        public ChatBot(IChatMediator chatMediator) : base(chatMediator)
        {
        }
    }
}