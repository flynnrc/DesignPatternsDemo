using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Builder
{
    //Note: This is demo code only for quick viewing, normally each class would have its own file

    //Builder is a creational pattern that allows you to construct complex objects step by step
    //The builder pattern allows the creation of different types and representations of the Object being built
    //Builder can cut down on class creep

    //This demo is building a Robot

    //IRobotBuilder is one specific contract for constructing Robots, there can be different contracts for a Robot
    public interface IRobotBuilder
    {
        //Added return type of IRobotBuilder in order to to enable fluid syntax

        //Build part 1
        IRobotBuilder BuildRobotCore();

        //Build part 2
        IRobotBuilder BuildRobotLegs();

        //Build part 3
        IRobotBuilder BuildRobotArms();

        ////non-fluid void return
        //void BuildPartA();
        //void BuildPartB();
        //void BuildPartC();
    }

    //Here is the Robot class
    public class Robot
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            var sb = new StringBuilder();
            sb.Append("Robot parts: ");

            for (int i = 0; i < _parts.Count; i++)
            {
                sb.Append($"({_parts[i]}),");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("\n");

            return $" {sb.ToString()} ";
        }
    }

    //The concrete builder implements the builder contract
    //Different builders could implement the same contract in different ways
    //The Builder assembles the Parts of an object (in this case the parts of a Robot)
    public class ConcreteRobotBuilder : IRobotBuilder
    {
        private Robot robot = new Robot();

        //should start fresh when creating a new robot
        public ConcreteRobotBuilder()
        {
            this.Reset();
        }

        private void Reset()
        {
            this.robot = new Robot();
        }


        //Build Methods Build parts
        public IRobotBuilder BuildRobotCore()
        {
            robot.Add("Robot Brains");
            return this;
        }

        public IRobotBuilder BuildRobotLegs()
        {
            robot.Add("Robot Legs");
            return this;
        }

        public IRobotBuilder BuildRobotArms()
        {
            robot.Add("Robot Arms");
            return this;
        }

        public Robot GetRobot()
        {
            var result = this.robot;
            return result;
        }

        //optional
        //public Robot GetAndResetRobot()
        //{
        //    var result = this.robot;

        //    this.Reset();//it's not manditory to reset here, but typically once you GET, it's done building

        //    return result;
        //}
    }

    //This is a Director class
    //The Director assembles the parts into a whole, whereas the Builder focuses on building the parts
    //The Director is responsible for the various assemblies, how to assemble them, which parts, and what order
    public class Director
    {
        private IRobotBuilder _robotBuilder;

        public IRobotBuilder Builder
        {
            set { _robotBuilder = value; }
        }

        // The Director can construct several product variations using the same building steps.

        //Product variation 1
        public void BuildLowBudgetRobot()
        {
            this._robotBuilder.BuildRobotCore();
        }

        //Product variation 2
        public void BuildFullFeaturedRobot()
        {
            this._robotBuilder.BuildRobotCore();
            this._robotBuilder.BuildRobotLegs();
            this._robotBuilder.BuildRobotArms();
        }
    }
}
