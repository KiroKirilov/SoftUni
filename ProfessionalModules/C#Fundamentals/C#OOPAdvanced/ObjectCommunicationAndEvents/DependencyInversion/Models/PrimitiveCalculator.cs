
using System.Collections.Generic;

public class PrimitiveCalculator
{
    private bool isAddition;
    private IStrategy strategy;
    private Dictionary<char, IStrategy> strategies;

    public PrimitiveCalculator()
    {
        this.isAddition = true;
        this.strategies = new Dictionary<char, IStrategy>()
        {
            { '+', new AdditionStrategy()},
            { '-', new SubtractionStrategy()},
            { '*', new MultiplicationStrategy()},
            { '/', new DivisionStrategy()},
        };
        this.strategy = strategies['+'];
    }

    public void ChangeStrategy(char @operator)
    {
        this.strategy = strategies[@operator];
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}
