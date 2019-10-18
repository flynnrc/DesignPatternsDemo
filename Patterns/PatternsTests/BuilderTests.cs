using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Builder;
using System;

namespace PatternsTests
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void Director_BuildLowBudgetRobot_ShouldHaveExpectedParts()
        {
            //Arrange
            var director = new Director();
            var builder = new ConcreteRobotBuilder();
            director.Builder = builder;

            //Act
            director.BuildLowBudgetRobot();
            var robotParts = builder.GetRobot().ListParts();

            //Assert
            Assert.IsTrue(robotParts == " Robot parts: (Robot Brains)\n ");
        }

        [TestMethod]
        public void Director_BuildFullFeaturedRobot_ShouldHaveExpectedParts()
        {
            //Arrange
            var director = new Director();
            var builder = new ConcreteRobotBuilder();
            director.Builder = builder;

            //Act
            director.BuildFullFeaturedRobot();
            var robotParts = builder.GetRobot().ListParts();

            //Assert
            Assert.IsTrue(robotParts == " Robot parts: (Robot Brains),(Robot Legs),(Robot Arms)\n ");
        }

        [TestMethod]
        public void RobotBuilder_OnlyBuildRobotCore_ShouldOnlyHaveRobotCore()
        {
            //this test does not use the director

            //Arrange
            var builder = new ConcreteRobotBuilder();

            //Act
            builder.BuildRobotCore();
            var robotParts = builder.GetRobot().ListParts();

            //Assert
            Assert.IsTrue(robotParts == " Robot parts: (Robot Brains)\n ");
        }
    }
}
