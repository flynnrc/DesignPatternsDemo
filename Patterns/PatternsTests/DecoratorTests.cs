using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsTests
{
    [TestClass]
    public class DecoratorTests
    {
        [TestMethod]
        public void Decorator_ArmoredBear_ShouldHaveBonusArmor()
        {
            //Decorator Pattern to attach new behaviors to an object
            //This test takes a normal bear and decorates it in armor, and then checks the Health value of the bear

            //Arrange
            var bear = new BasicBear();
            var additionalHealth = 1;

            //Act
            var armoredBear = new ArmoredBear(bear);

            //Assert
            Assert.IsTrue(armoredBear.Health == bear.Health + additionalHealth);
        }

        [TestMethod]
        public void Decorator_ArmoredBearTwice_ShouldHaveExpectedArmor()
        {
            //Decorator Pattern to attach new behaviors to an object
            //This test takes a normal bear and decorates it in armor, and then checks the Health value of the bear

            //Arrange
            var bear = new BasicBear();
            var additionalArmor = 2;

            //Act
            var armoredHealth = new ArmoredBear(bear);
            armoredHealth = new ArmoredBear(armoredHealth);

            //Assert
            Assert.IsTrue(armoredHealth.Health == bear.Health + additionalArmor);
        }

        [TestMethod]
        public void Decorator_ArmoredBear_HasExpectedComments()
        {
            //Decorator Pattern to attach new behaviors to an object
            //This test takes a normal bear and decorates it in armor, and looks at the Commentary field changes

            //Arrange
            var bear = new BasicBear();
            var comment1 = "It's a bear, with armor.";
            var comment2 = "Fury";

            //Act
            var armoredBear = new ArmoredBear(bear);

            //Assert
            Assert.IsTrue(armoredBear.Commentary.Contains(comment1) && armoredBear.Commentary.Contains(comment2));
        }
    }
}
