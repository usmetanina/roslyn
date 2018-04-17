using System;
using System.Reflection;

namespace roslyn
{
    [Serializable]
    public class Globals
    {
        public int X;
        public int Y;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain domain = AppDomain.CreateDomain("test");
            domain.Load(Assembly.GetExecutingAssembly().GetName());
            var calc = (Calculator)domain.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName, "roslyn.Calculator");

            while (true)
            {
                Console.Write(">> ");
                var input = Console.ReadLine();

                if (input == "exit")
                    break;

                Console.WriteLine("Введите X");
                var x = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите Y");
                var y = Convert.ToInt32(Console.ReadLine());

                var gl = new Globals { X = x, Y = y };
                Console.WriteLine(calc.Calc(input, gl)); 
            }
        }
    }
}
