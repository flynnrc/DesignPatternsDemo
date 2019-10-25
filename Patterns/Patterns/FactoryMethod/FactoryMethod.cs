using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.FactoryMethod
{
    //Note: This is demo code only for quick viewing, normally each class would have its own file

    //Factory Method
    //Allows a class to defer instantiation to subclasses, and to prevent direct instantiation of an object of the parent class type.
    //Use Factory Methods when you want to reuse common functionality with different components and decouple the implementation from its usage
    //To use, define an interface, abstraction, or default implementation that can then be implemented or overriden by a concrete class 

    #region Abstract BreadStore w/Factory Method
    //The abstract class BreadStore declares a factory method for its subclasses to implement
    public abstract class BreadStore
    {
        //the factory method -- it can be completely abstract or have a default implmentation
        protected abstract IBread CreateBread();

        //This method calls the Factory Method -- the subclass knows which bread to get
        public string OrderBread()
        {
            var bread = CreateBread();
            bread.Prepare();
            bread.Bake();
            bread.Package();
            return bread.GetName();
        }
    }

    #endregion

    #region Derived BreadStores w/Factory Method Implementations

    //Derived classes that implement the Factory Method

    public class FlatBreadStore : BreadStore
    {
        protected override IBread CreateBread()
        {
            return new PitaBread();
        }
    }

    public class FrenchBreadStore : BreadStore
    {
        protected override IBread CreateBread()
        {
            return new FrenchBread();
        }
    }

    #endregion

    #region Breads

    //Bread is the return type of the Factory Method implementations in this example
    //The store subclasses choose which Bread to produce

    //Declares the Bread contract
    public interface IBread
    {
        void Prepare();
        void Bake();
        void Package();
        string GetName();
    }

    //some default implementation for certain Breads to derive from
    public abstract class Bread : IBread
    {
        public abstract void Prepare();
        public void Bake() { }
        public void Package() { }
        public abstract string GetName();
    }

    //concrete breads
    public class PitaBread : Bread
    {
        public override string GetName()
        {
            return "Made a Pita Bread";
        }

        public override void Prepare()
        {
            //doing something unique for this bread type
        }

    }

    public class FrenchBread : Bread
    {
        public override string GetName()
        {
            return "Made a French Bread";
        }

        public override void Prepare()
        {
            //doing something unique for this bread type
        }

    }
   
    #endregion
}
