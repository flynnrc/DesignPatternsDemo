using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.SimpleFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsTests
{
    [TestClass]
    public class SimpleFactoryTests
    {
        [TestMethod]
        public void FactoryMethod_SimpleIceCreamFactory_ShouldReturnChocolate()
        {
            //Arrange
            var flavor = Flavor.Chocolate;
            var expected = "Chocolate";

            //Act

            //Simple Factory only encapsulates object creation
            //Notice some info must be Passed into the Create method, so there is a dependency
            var result = SimpleIceCreamFactory.Create(flavor);

            //Assert
            Assert.IsTrue(result.GetType().Name == expected);
        }
    }
}
