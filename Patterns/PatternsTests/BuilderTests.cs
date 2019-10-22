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
            //Builder Pattern to construct a complex object with several representations
            //This test uses the Director class to build the preset option of a Low Budget Robot

            //Arrange
            var director = new Director();
            var builder = new ConcreteRobotBuilder();
            director.Builder = builder;
            var expectedParts = " Robot parts: (Robot Brains)\n ";

            //Act
            director.BuildLowBudgetRobot();
            var robotParts = builder.GetRobot().ListParts();

            //Assert
            Assert.IsTrue(robotParts == expectedParts);
        }

        [TestMethod]
        public void Director_BuildFullFeaturedRobot_ShouldHaveExpectedParts()
        {
            //Builder Pattern to construct a complex object with several representations
            //This test uses the Director class to build the preset option of a Full Featured Robot

            //Arrange
            var director = new Director();
            var builder = new ConcreteRobotBuilder();
            director.Builder = builder;
            var expectedParts = " Robot parts: (Robot Brains),(Robot Legs),(Robot Arms)\n ";

            //Act
            director.BuildFullFeaturedRobot();
            var robotParts = builder.GetRobot().ListParts();

            //Assert
            Assert.IsTrue(robotParts == expectedParts);
        }

        [TestMethod]
        public void RobotBuilder_OnlyBuildRobotCore_ShouldOnlyHaveRobotCore()
        {
            ////Builder Pattern to construct a complex object with several representations
            //This test does not use the optional Director class
            //It directly uses the concrete class to build a Robot

            //Arrange
            var builder = new ConcreteRobotBuilder();
            var expectedParts = " Robot parts: (Robot Brains)\n ";

            //Act
            builder.BuildRobotCore();
            var robotParts = builder.GetRobot().ListParts();

            //Assert
            Assert.IsTrue(robotParts == expectedParts);
        }
    }
}
