using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatternsTests
{
    [TestClass]
    public class StrategyTests
    {
        [TestMethod]
        public void Strategy_MinStrategy_GetsMinNumber()
        {
            //Strategy Pattern
            //Test that one concrete strategy is working

            //Arrange
            var numbers = new List<int>() { 1, 2, 3, 4, 5};
            var strat = new ConcreteStrategyGetMin();
            var context = new Context(strat);

            //Act
            var result = context.SomeMethodUsingTheStrategy(numbers);

            Assert.IsTrue(numbers.Min() == result);
        }

        [TestMethod]
        public void Strategy_MaxStrategy_GetsMinNumber()
        {
            //Strategy Pattern
            //Test that one concrete strategy is working

            //Arrange
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            var strat = new ConcreteStrategyGetMax();
            var context = new Context(strat);

            //Act
            var result = context.SomeMethodUsingTheStrategy(numbers);

            Assert.IsTrue(numbers.Max() == result);
        }

        [TestMethod]
        public void Strategy_CanSwitchStrategyAtRuntime()
        {
            //Strategy Pattern
            //Test that strategy can be swapped at runtime

            //Arrange
            //var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            var strat = new ConcreteStrategyGetMax();
            var newStrat = new ConcreteStrategyGetMin();
            var context = new Context(strat);

            //Act
            context.SetCurrentStrategy(newStrat);
            var result = context.GetCurrentStrategy().GetType();

            Assert.IsTrue(newStrat.GetType().Name != result.GetType().Name);
        }
    }
}
