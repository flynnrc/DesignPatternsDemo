using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsTests
{
    [TestClass]
    public class FactoryMethodTests
    {
        [TestMethod]
        public void FactoryMethod_FlatBreadStore_ShouldMakePitaBread()
        {
            //Arrange
            var store = new FlatBreadStore();
            
            //Act
            var result = store.OrderBread();

            //Assert
            Assert.IsTrue(result.Contains("Made a Pita Bread"));
        }

        [TestMethod]
        public void FactoryMethod_FlatBreadStore_ShouldMakeFrenchBread()
        {
            //Arrange
            var store = new FrenchBreadStore();
            
            //Act
            var result = store.OrderBread();

            //Assert
            Assert.IsTrue(result.Contains("French"));
        }
    }
}
