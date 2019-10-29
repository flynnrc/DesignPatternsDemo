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
        public void FactoryMethod_FreshWaterAnimalFactory_ShouldReturnFreshWaterAnimal()
        {
            //Arrange
            var sut = new FreshWaterAnimalFactory();

            //Act
            var result = sut.GetAnimal();

            //Assert
            Assert.IsTrue(result.GetType().Name == "Frog");
        }

        [TestMethod]
        public void FactoryMethod_HouseHoldAnimalFactory_ShouldReturnHouseholdAnimal()
        {
            //Arrange
            var sut = new HouseHoldAnimalFactory();

            //Act
            var result = sut.GetAnimal();

            //Assert
            Assert.IsTrue(result.GetType().Name == "Dog");
        }
    }
}
