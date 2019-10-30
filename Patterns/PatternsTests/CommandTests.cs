using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsTests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void Command_LightBulb_ExecuteNextCommand()
        {
            //Arrange
            var commandInvoker = new CommandInvoker();
            var receiver = new Lightbulb();
            Assert.IsFalse(receiver.IsOn);

            //Act
            commandInvoker.AddCommand(new TurnOnLightCommand(receiver));
            commandInvoker.ExecuteNextCommand();

            //Assert
            Assert.IsTrue(receiver.IsOn);
        }

        [TestMethod]
        public void Command_LightBulb_UndoLastCommand()
        {
            //Arrange
            var commandInvoker = new CommandInvoker();
            var receiver = new Lightbulb();
            Assert.IsFalse(receiver.IsOn);

            //Act
            commandInvoker.AddCommand(new TurnOnLightCommand(receiver));
            commandInvoker.ExecuteNextCommand();
            Assert.IsTrue(receiver.IsOn);

            commandInvoker.UndoLastCommand();
            Assert.IsFalse(receiver.IsOn);
        }
    }
}
