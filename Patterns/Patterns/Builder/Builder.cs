using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Builder
{
    //Note: This is demo code only for quick viewing, normally each class would have its own file

    //Builder is a creational pattern that allows you to construct complex objects step by step
    //The builder allows the creation of different types and representations of an Object
    //Builder can cut down on class creep, use best judgement to determine if it's worth implementing
    //Different builders can execute the same task in various ways.

    //This example is building the object Robot

    //IRobotBuilder is one specific contract for constructing Robots
    //Different RobotBuilder contracts could exist
    public interface IRobotBuilder
    {
        //Added return type of IRobotBuilder in order to to enable fluid syntax
        IRobotBuilder BuildRobotCore();

        IRobotBuilder BuildRobotLegs();

        IRobotBuilder BuildRobotArms();

        ////non-fluid void return
        //void BuildPartA();
        //void BuildPartB();
        //void BuildPartC();
    }

    //Robot is what is being constructed
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
    //There can also be various contracts
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


        //Build Methods
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

            //this.Reset();//it's not manditory to reset here, but typically once you GET it's done building//but I would rename Get to GetAndReset

            return result;
        }
    }

    //Optionally there is a Director class 
    //The Director class can define the order in which build steps are executed
    //The Director may also know several combinations of build steps to execute in order to get various valid Robot builds
    public class Director
    {
        private IRobotBuilder _robotBuilder;

        public IRobotBuilder Builder
        {
            set { _robotBuilder = value; }
        }

        // The Director can construct several product variations using the same building steps.
        public void BuildLowBudgetRobot()
        {
            this._robotBuilder.BuildRobotCore();
        }

        public void BuildFullFeaturedRobot()
        {
            this._robotBuilder.BuildRobotCore();
            this._robotBuilder.BuildRobotLegs();
            this._robotBuilder.BuildRobotArms();
        }
    }
}
