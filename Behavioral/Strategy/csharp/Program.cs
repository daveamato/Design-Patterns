﻿using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            SendCargo cargo = new SendCargo();

            cargo.SetCargoMethod(new YurticiCargo { Order_id = "ASDF" });
            cargo.Send();

            cargo.SetCargoMethod(new MngCargo { Order_id = "ASDF" });
            cargo.Send();

            Console.Read();
        }
    }

    public interface ICargo
    {
        void Send();
    }

    public class YurticiCargo : ICargo
    {
        public string Order_id { get; set; }

        public void Send()
        {
            //related transactions

            Console.WriteLine($"Domestic cargo was shipped.");
        }
    }

    public class MngCargo : ICargo
    {
        public string Order_id { get; set; }

        public void Send()
        {
            //related transactions

            Console.WriteLine($"Mng was shipped by cargo.");
        }
    }

    public class SendCargo
    {
        private ICargo cargo;

        public void SetCargoMethod(ICargo cargo)
        {
            this.cargo = cargo;
        }

        public void Send()
        {
            cargo.Send();
        }
    }
}