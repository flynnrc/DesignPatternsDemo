using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.FactoryMethod
{
    //Note: This is demo code only for quick viewing, normally each class would have its own file

    #region Bread Stores

    //This BreadStore class will have the factory method that will return a type of bread to create.
    //Other classes will derive from this and add the implementation of CreateBread, taking the responsiblity of what bread to create.
    public abstract class BreadStore
    {
        //the factory method -- it could have some default implementation
        protected abstract IBread CreateBread();

        //This method will use the above factory method to produce a bread
        //The store is responsible for the type of bread, the other steps are generic
        public string OrderBread()
        {
            var bread = CreateBread();
            bread.Prepare();
            bread.Bake();
            bread.Package();
            return bread.GetName();
        }
    }

    //here are the derived classes that have implementations for the FactoryMethod
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

    //These are the Bread interfaces and implementations
    //The factory method of a store will ultimately return a Bread implementation to the store

    public abstract class Bread : IBread
    {
        public abstract void Prepare();
        public void Bake() { }
        public void Package() { }
        public abstract string GetName();
    }

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

    public interface IBread
    {
        void Prepare();
        void Bake();
        void Package();
        string GetName();
    }
    #endregion
}
