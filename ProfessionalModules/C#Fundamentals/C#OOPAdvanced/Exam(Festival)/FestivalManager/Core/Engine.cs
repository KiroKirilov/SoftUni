
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;

    /// <summary>
    /// by Kiro Maina
    /// </summary>
    public class Engine : IEngine
    {
        private const string EndCommand = "END";
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalController;
        private ISetController setController;

        public Engine(IReader reader,IWriter writer,IFestivalController festivalController,ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
        }

        public void Run()
        {
            string input = "";

            while ((input = Console.ReadLine())!=EndCommand)
            {
                try
                {
                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (TargetInvocationException tie)
                {
                    this.writer.WriteLine($"ERROR: {tie.InnerException.Message}");
                }
                catch (Exception e)
                {
                    this.writer.WriteLine($"ERROR: {e.Message}");
                }
            }
            this.writer.WriteLine("Results:");
            this.writer.WriteLine(this.festivalController.ProduceReport());
        }

        public string ProcessCommand(string input)
        {
            string[] args = input.Split();
            string commandName = args[0];
            string[] commandArgs = args.Skip(1).ToArray();
            string result = "";

            if (commandName=="LetsRock")
            {
                result = this.setController.PerformSets();
            }
            else
            {
                Type controllerType = typeof(FestivalController);

                MethodInfo methodToInvoke = controllerType.GetMethod(commandName);

                result =(string)methodToInvoke.Invoke(this.festivalController,new object[] { commandArgs });
            }

            return result;
        }
    }
}