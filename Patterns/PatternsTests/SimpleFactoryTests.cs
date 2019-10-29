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

            //Act
            var result = SimpleIceCreamFactory.Create(flavor);

            //Assert
            Assert.IsTrue(result.GetType().Name == "Chocolate");
        }
    }
}
