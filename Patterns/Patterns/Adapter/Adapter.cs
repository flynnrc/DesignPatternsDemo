using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Adapter
{
    //Note: This is demo code only for quick viewing, normally each class would have its own file

    //Adapter Pattern
    //Allows two incompatible interfaces to work together by creating an adapter class to map one to the other
    //this can also be used to efficiently add a common interface to a group of subclasses that are missing something to be cohesive
    //very similiar to decorator, except adaptor actually changes the interface whereas decorator does not

    //In this example, we'll be adapting an IDonut to an ISnackInfo. 

    //Incompatable interface 1 
    public interface ISnackInfo
    {
        int GetCalorieCount();
    }

    //Incompatable interface 2 
    public interface IDonut
    {
        int GetGramsOfSugar();
        int GetGramsOfFat();
    }

    //Adaptee -- a concrete of IDonut to be used by the Adapter
    public class Donut : IDonut
    {
        private int _gramsOfFat;
        private int _gramsOfSugar;

        public Donut(int gramsOfFat, int gramsOfSugar)
        {
            this._gramsOfFat = gramsOfFat;
            this._gramsOfSugar = gramsOfSugar;
        }

        public int GetGramsOfFat()
        {
            return _gramsOfFat;
        }

        public int GetGramsOfSugar()
        {
            return _gramsOfSugar;
        }
    }

    //The Adapter makes the Adaptee's interface compatable with the target interface
    //In this example, IDonut is the Adaptee being adapted to ISnackInfo to get the number of Calories
    public class DonutToSnackInfoAdapter : ISnackInfo
    {
        private readonly IDonut _donut;

        public DonutToSnackInfoAdapter(IDonut donut)
        {
            _donut = donut;
        }

        public int GetCalorieCount()
        {
            return (_donut.GetGramsOfFat() * 9) + (_donut.GetGramsOfSugar() * 4);
        }
    }
}
