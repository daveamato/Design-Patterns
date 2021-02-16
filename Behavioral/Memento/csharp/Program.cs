using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            ProfileSettingsCareTaker careTaker = new ProfileSettingsCareTaker();

            ProfileSettings profileSettings = new ProfileSettings
            {
                UserName = "damato",
                Name = "David",
                Email = "d@amato.tk",
                Age = 34
            };

            Console.WriteLine(profileSettings.ToString());

            careTaker.Memento = profileSettings.Backup();

            profileSettings.Name = "Bot";
            profileSettings.UserName = "bot";

            Console.WriteLine("*****\n" + profileSettings.ToString());

            profileSettings.SetDefaultProfileSettings(careTaker.Memento);

            Console.WriteLine("*****\n" + profileSettings.ToString());

            Console.Read();
        }
    }

    public class ProfileSettings
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        //settings will make a copy of our object.
        public ProfileSettingsMemento Backup()
        {
            ProfileSettingsMemento settingsMemento = new ProfileSettingsMemento
            {
                UserName = UserName,
                Name = Name,
                Email = Email,
                Age = Age
            };

            return settingsMemento;
        }

        //we return the data from the copy we received to our profilesettings object.
        public void SetDefaultProfileSettings(ProfileSettingsMemento settingsMemento)
        {
            UserName = settingsMemento.UserName;
            Name = settingsMemento.Name;
            Email = settingsMemento.Email;
            Age = settingsMemento.Age;
        }

        public override string ToString()
        {
            return $"Username: {UserName}\nName: {Name}\nEmail: {Email}\nAge: {Age}";
        }
    }

    public class ProfileSettingsMemento
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

    }

    //The class that will keep the previous state of the Memento type.
    public class ProfileSettingsCareTaker
    {
        public ProfileSettingsMemento Memento { get; set; }
    }
}