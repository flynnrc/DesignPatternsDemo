using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Strategy
{
    //Note: This is demo code only for quick viewing, normally each class would have its own file

    //Problems to solve: 
    //1.) ability to change strategy at runtime as long as it follows the interface contract
    //2.) encapsulates each algorithm in family of algorithms, each algorithm can be used interchangibly

    //The strategy interface sets a contract for all supported versions of an alorithm
    public interface IExtractNumberStrategy
    {
        int ExtractNumber(List<int> numbers);
    }

    //The Context represents what is relying on these various concrete strategies to do work
    //The context holds a reference to an IStrategy, the reference can be swapped, and different implementations can be brought in during runtime to do work
    public class Context
    {
        private IExtractNumberStrategy _strategy;

        //Constructor can take a default strategy
        public Context(IExtractNumberStrategy currentStrategy)
        {
            this._strategy = currentStrategy;
        }

        //Setter to update the strategy
        public void SetCurrentStrategy(IExtractNumberStrategy strategy)
        {
            this._strategy = strategy;
        }

        public IExtractNumberStrategy GetCurrentStrategy()
        {
            return _strategy;
        }

        //Context delegates the work to the strategy object, so that the context doesn't need to know the current strategy
        public int SomeMethodUsingTheStrategy(List<int> numbers)
        {
            return _strategy.ExtractNumber(numbers);
        }
    }

    #region Concrete Strategies

    public class ConcreteStrategyGetMin : IExtractNumberStrategy
    {
        //Concrete implementation -- one possible implementation within the bounds of the contract
        public int ExtractNumber(List<int> numbers)
        {
            return numbers.Min();
        }
    }

    public class ConcreteStrategyGetMax : IExtractNumberStrategy
    {
        //Concrete implementation -- one possible implementation within the bounds of the contract
        public int ExtractNumber(List<int> numbers)
        {
            return numbers.Max();
        }
    }

    #endregion
   
    public class SomeDemoOnlyStrategyDeterminer
    {
        //represents some outside process that could be used to dynamically determine a new strategy
        //this is not part of the pattern, but could be part of an overall implementation
        //this is simplified, any actual strategy determiner would depend on the specifics of a real solution
        public IExtractNumberStrategy GetCurrentStrategy(int n)
        {
            if (n % 2 == 0)
            {
                return new ConcreteStrategyGetMin();
            }
            else
            {
                return new ConcreteStrategyGetMax();
            }
        }
    }
}
