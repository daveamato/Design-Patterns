using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Purchasing purchasing = new Computer();
            purchasing.TemplateMethod();

            Console.Read();
        }
    }

    public enum PaymentType
    {
        KrediKarti,
        HavaleEft
    }

    public enum CargoCompany
    {
        Yurtici,
        Aras
    }

    public abstract class Purchasing
    {
        protected string ProductName;
        protected PaymentType PaymentType;
        protected CargoCompany cargoCompany;

        static void Start() => Console.WriteLine($"Order creation has started.");
        void Step0() => Console.WriteLine($"The product was added to the cart. Product name: {ProductName}");
        void Step1() => Console.WriteLine($"It's been paid for. Payment method: {PaymentType}");
        void Step2() => Console.WriteLine($"The shipping company has been chosen. Selected: {cargoCompany}");
        static void Finish() => Console.WriteLine("Order complete.");

        public abstract void Product();
        public abstract void Payment();
        public abstract void Cargo();


        public void TemplateMethod()
        {
            Start(); //fixed function
            Step0();
            Step1();
            Step2();
            Finish(); //fixed function
        }
    }

    public class Computer : Purchasing
    {
        public override void Product()
        {
            ProductName = "MonsterNotebook";
        }

        public override void Payment()
        {
            PaymentType = PaymentType.KrediKarti;
        }

        public override void Cargo()
        {
            cargoCompany = CargoCompany.Yurtici;
        }
    }
}