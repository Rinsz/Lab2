using System;
using System.IO;

namespace SortBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type \"help\" to see available commands");
            var userInput = "nothing";
            
            while (!string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Enter command: ");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "generate-exp-data":
                        Console.WriteLine("Enter name for your xml file (without extension): ");
                        ExperimentXmlGenerator.GenerateExperimentXml(Console.ReadLine());
                        break;
                    case "run-experiment": RunExperiment(); break;
                    case "help":
                        Console.WriteLine("generate-exp-data:\t Creates xml file to run experiments with your data\n" +
                                          "run-experiment:\t Starts experiment with your xml data file\n" +
                                          "help:\t Shows available commands");
                        break;
                    case "": break;
                    case null: break;
                    default: Console.WriteLine("This command does not exist. Type help to see existing commands");
                        break;
                }
            }
        }

        private static void RunExperiment()
        {
            Console.WriteLine("Enter name of your xml experiment data file (without extension): ");
            var filename = Console.ReadLine();
            
            if (!File.Exists($"{filename}.xml"))
            {
                Console.WriteLine("This file does not exists. Do you want to generate new file? (Y/N)");
                switch (Console.ReadLine().ToLower())
                {
                    case "y": ExperimentXmlGenerator.GenerateExperimentXml(filename);
                        break;
                    default: return;
                }
            }

            Console.WriteLine("Running experiment\n");
            ExperimentRunner.RunExperiment(filename);
            Console.WriteLine("Experiment completed\n");
        }
    }
}