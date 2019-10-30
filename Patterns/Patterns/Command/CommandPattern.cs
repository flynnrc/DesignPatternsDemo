using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    //Command Pattern:
    //Encapsulates requests 
    //Inject that command object into an invoker
    //The invoker class can be as fancy or as simple as needed (undo, repeat, batch commands etc...)
    //The concrete commands act on a receiver
    //command classes are usually limited to specific actions some support undo functionality

    //Command contract
    public interface ICommand
    {
        void Execute();
        //often an undo command is added in
        void Undo();
    }

    //Concrete command
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
    //Receiver -- Something commands can act on
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

    //Invoker -- Coordinates commands
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
}
