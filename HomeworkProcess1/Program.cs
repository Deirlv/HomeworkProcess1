using System;
using System.Diagnostics;
using System.Reflection;

namespace HomeworkProcess1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int answer;
            Console.WriteLine("1 - Start Process And Wait, \n2 - Custom Process Actions, \n3 - Process Calculator");
            int.TryParse(Console.ReadLine(), out answer);

            Console.Clear();

            switch (answer)
            {
                case 1: StartProcessAndWait("calc.exe"); break;

                case 2: CustomProcessActions(); break;

                case 3: ProcessCalculator(); break;
            }
        }

        public static void StartProcessAndWait(string processName)
        {
            Process process = new Process();
            process.StartInfo.FileName = processName;

            process.Start();

            process.WaitForExit();

            int exitCode = process.ExitCode;
            Console.WriteLine($"Process has ended with code: {exitCode}");
        }

        public static void CustomProcessActions()
        {
            Console.Write("Process: ");
            string processName = Console.ReadLine();
            Process process = new Process();
            process.StartInfo.FileName = processName;
            if(process.Start() == true)
            {
                int action;
                Console.WriteLine("1 - Wait for exit, \n2 - Exit: ");
                int.TryParse(Console.ReadLine(), out action);

                Console.Clear();

                if (action == 1)
                {
                    process.WaitForExit();

                    int exitCode = process.ExitCode;

                    Console.WriteLine($"Process has ended with code: {exitCode}");
                }
                else if (action == 2)
                {
                    process = Process.GetProcessesByName("CalculatorApp").FirstOrDefault();
                    process.Kill();
                    process.WaitForExit();
                }
            }
        }

        public static void ProcessCalculator()
        {
            int number1;
            Console.Write("First Number: ");
            int.TryParse(Console.ReadLine(), out number1);

            int number2;
            Console.Write("Second Number: ");
            int.TryParse(Console.ReadLine(), out number2);

            char operation;
            Console.Write("Operation: ");
            char.TryParse(Console.ReadLine(), out operation);

            Process process = new Process();

            string path = "calc.exe";

            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = $"{number1} {number2} {operation}";

            process.Start();
        }
    }
}
