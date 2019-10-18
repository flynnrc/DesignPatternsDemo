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
            //Arrange
            var bear = new BasicBear();

            //Act
            var armoredBear = new ArmoredBear(bear);

            //Assert
            Assert.IsTrue(armoredBear.Health == bear.Health + 1);
        }

        [TestMethod]
        public void Decorator_ArmoredBear_HasExpectedComments()
        {
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
