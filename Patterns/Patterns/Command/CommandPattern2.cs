using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Command
{
    ////Note: This is demo code only for quick viewing, normally you should put each class in its own file

    //Command Pattern:
    //Behavioral design pattern that converts requests or simple operations into objects

    //The core of the pattern is ICommand and Concrete Command, commands act on a business object
    //The Receiver class represents some business object that a Command acts on
    //The Invoker class manages Commands according to "what needs to be done" for the business logic (batch, logging, undo, history etc...)

    #region Commands
    public interface ICommand
    {
        CommandResult Execute();//could return void or any other type of Result object
    }
    #endregion

    #region Concrete commands

    //Commands Encapsulate the execution of a receivers action

    //Command
    public class JumpCommand : ICommand
    {
        private ICharacterController controller;

        public JumpCommand(ICharacterController controller)
        {
            this.controller = controller;
        }

        public CommandResult Execute()
        {
            var res = controller.Jump();
            return new CommandResult() { Response = res };
        }
    }

    //Command
    public class DashCommand : ICommand
    {
        private ICharacterController controller;

        public DashCommand(ICharacterController controller)
        {
            this.controller = controller;
        }

        public CommandResult Execute()
        {
            var res = controller.Dash();
            return new CommandResult() { Response = res };
        }
    }

    #endregion

    #region Receiver

    //The receiver is the object that commands act on

    public class Character : ICharacterController
    {
        public Character()
        {
            //init some kind of character
        }

        public string Jump()
        {
            return "Jump!";
        }

        public string Dash()
        {
            return "Dash!";
        }
    }

    public interface ICharacterController
    {
        string Dash();
        string Jump();
    }
    #endregion

    #region Invoker

    //Manages commands according to what the Business context needs
    public class ButtonCommandInvoker{

        private readonly ICommand buttonACommand;
        private readonly ICommand buttonBCommand;

        public ButtonCommandInvoker(ICommand a, ICommand b)
        {
            buttonACommand = a;
            buttonBCommand = b;
        }

        public CommandResult ClickButtonA()
        {
            return buttonACommand.Execute();
        }

        public CommandResult ClickButtonB()
        {
            return buttonBCommand.Execute();
        }
    }

    #endregion

    public class CommandResult
    {
        public string Response { get; set; }
    }
}
