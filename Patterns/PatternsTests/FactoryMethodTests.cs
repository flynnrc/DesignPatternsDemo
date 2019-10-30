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
            var expectedAnimal = "Frog";
            var sut = new FreshWaterAnimalFactory();

            //Act

            //this is the factory method call, notice no info is passed, the factory is independent
            var result = sut.GetAnimal();

            //Assert
            Assert.IsTrue(result.GetType().Name == expectedAnimal);
        }

        [TestMethod]
        public void FactoryMethod_HouseHoldAnimalFactory_ShouldReturnHouseholdAnimal()
        {
            //Arrange
            var expectedAnimal = "Dog";
            var sut = new HouseHoldAnimalFactory();

            //Act
            
            //this is the factory method call, notice no info is passed, the factory is independent
            var result = sut.GetAnimal();

            //Assert
            Assert.IsTrue(result.GetType().Name == expectedAnimal);
        }
    }
}
