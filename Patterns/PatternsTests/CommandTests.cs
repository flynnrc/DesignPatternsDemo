using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns;
using Patterns.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsTests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void Command_CharacterToJump_ShouldJump()
        {
            //Arrange
            var characterController = new Character();
            var commandInvoker = new ButtonCommandInvoker(new JumpCommand(characterController), new DashCommand(characterController));

            //Act
            var result = commandInvoker.ClickButtonA();

            //Assert
            Assert.IsTrue(result.Response == "Jump!");
        }

        [TestMethod]
        public void Command_CharacterToDash_ShouldDash()
        {
            //Arrange
            var characterController = new Character();
            var commandInvoker = new ButtonCommandInvoker(new JumpCommand(characterController), new DashCommand(characterController));

            //Act
            var result = commandInvoker.ClickButtonA();

            //Assert
            Assert.IsTrue(result.Response == "Jump!");
        }
    }
}
