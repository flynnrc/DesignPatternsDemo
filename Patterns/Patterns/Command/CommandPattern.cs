using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    

    //Command contract
    public interface ICommand
    {
        void Execute();
        //often an undo command is added in
        void Undo();
    }

    //Concrete command 1
    public class TurnOnLightCommand : ICommand
    {
        private Lightbulb lb;

        public TurnOnLightCommand(Lightbulb lb)
        {
            this.lb = lb;
        }

        public void Execute()
        {
            lb.IsOn = true;
        }

        public void Undo()
        {
            lb.IsOn = false;
        }
    }

    #region Receiver
    //Receiver -- Something a command can act on
    public class Lightbulb : ILight
    {
        public Lightbulb()
        {
            IsOn = false;
        }

        public bool IsOn { get; set; }
    }

    //Just an interface for Lightbulbs, not part of pattern
    public interface ILight
    {
        bool IsOn { get; set; }
    }
    #endregion

    #region Invoker
    //Invoker -- Coordinates and keeps track of ICommands 
    //-- not part of the core pattern, and you could create any invokers so long as they accept ICommands
    //Invokers could be a command queue or a straight up mapping of commands, it's free
    public class CommandInvoker
    {
        public static Queue<ICommand> commandStack = new Queue<ICommand>();
        public static Stack<ICommand> commandHistory = new Stack<ICommand>();

        public void AddCommand(ICommand command)
        {
            commandStack.Enqueue(command);
        }

        public void ExecuteNextCommand()
        {
            var currentCommand = commandStack.Peek();
            currentCommand.Execute();
            commandStack.Dequeue();
            commandHistory.Push(currentCommand);
        }

        public void UndoLastCommand()
        {
            var command = commandHistory.Pop();
            command.Undo();
        }
    }

    #endregion
}
