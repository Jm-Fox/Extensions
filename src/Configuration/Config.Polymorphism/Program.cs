using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;

namespace PolymorphicSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a config name: ");
            string configName = Console.ReadLine();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configName);
            ExpressionTypeResolver typeResolver = new ExpressionTypeResolver();
            ExpressionBase expression = builder.Build().Get<ExpressionBase>(options => options.StrategyResolver = typeResolver.ResolveStrategy);
            Console.WriteLine("Expression from configuration:");
            Console.WriteLine(JsonConvert.SerializeObject(expression, Formatting.Indented));
            Console.WriteLine();

            Console.Write("Enter a DateTime to evaluate: ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Evaluation: " + expression.Evaluate(dateTime));
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}