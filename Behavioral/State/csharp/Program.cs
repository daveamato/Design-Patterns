using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Context context = new Context();
            Console.WriteLine("Initial status of the lamp: " + context.GetLampState().ToString());

            context.OnClose();
            context.OnOpen();

            Console.WriteLine("Current status of the lamp: " + context.GetLampState().ToString());

            Console.Read();
        }
    }

    public interface ILampState
    {
        public void OnOpen();
        public void OnClose();
    }

    public class LampOpenState : ILampState
    {
        public void OnClose()
        {
            Console.WriteLine("The lamp's on. It's closing.");
        }

        public void OnOpen()
        {
            Console.WriteLine("The lamp's already on.");
        }

        public override string ToString()
        {
            return "On";
        }
    }

    public class LampCloseState : ILampState
    {
        public void OnClose()
        {
            Console.WriteLine("The lamp's already off.");
        }

        public void OnOpen()
        {
            Console.WriteLine("The lamp was off. Opening.");
        }

        public override string ToString()
        {
            return "Off";
        }
    }

    public class Context
    {
        private ILampState LampState;

        public Context()
        {
            SetLampState(new LampCloseState());
        }

        public void OnOpen()
        {
            LampState.OnOpen();
            if (LampState is LampCloseState)
            {
                SetLampState(new LampOpenState());
            }
        }

        public void OnClose()
        {
            LampState.OnClose();
            if (LampState is LampOpenState)
            {
                SetLampState(new LampCloseState());
            }
        }

        public ILampState GetLampState()
        {
            return LampState;
        }

        public void SetLampState(ILampState lampState)
        {
            LampState = lampState;
        }
    }
}