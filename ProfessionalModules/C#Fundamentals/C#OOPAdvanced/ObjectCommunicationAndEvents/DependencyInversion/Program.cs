using System;


class Program
{
    static void Main(string[] args)
    {
        var calculator = new PrimitiveCalculator();

        var input = "";

        while ((input = Console.ReadLine()) != "End")
        {
            var cmdArgs = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            if (cmdArgs[0]=="mode")
            {
                calculator.ChangeStrategy(char.Parse(cmdArgs[1]));
            }
            else
            {
                var firstOperand = int.Parse(cmdArgs[0]);
                var secondOprand = int.Parse(cmdArgs[1]);
                Console.WriteLine(calculator.PerformCalculation(firstOperand,secondOprand));
            }
        }
    }
}

