using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.SimpleFactory
{

    //Simple Factory (SF) is not a true pattern, but it's a DRY code construct and a precursor to complex factories
    //SF encapsulates object creation
    //One drawback of SF is that object creation is coupled to the creator, so code changes are required to stay in sync
    //In some cases the SF may become too complicated, which may indicate that it's time to swap it for a complex factory
    //The factory method pattern completely decouples object creation and adds polymorphism. SF only handles creation.

    //Implementation -- typically SF is achieved by a single class called a factory, a product Interface, and concrete products

    //This example uses an IceCreamFactory. 
    //The ice cream factory accepts an enum to help determine what time of ice cream product to produce.
    //Any ice cream can be produced, so long as it's a part of the factory and it adheres to the interface contract

    #region Factory -- Ice Cream Factory
    public class SimpleIceCreamFactory
    {
        public static IIceCream Create(Flavor type)
        {
            switch (type)
            {
                case Flavor.Vanilla:
                    {
                        return new Vanilla();
                    }
                case Flavor.Chocolate:
                    {
                        return new Chocolate();
                    }
                case Flavor.Strawberry:
                    {
                        return new Strawberry();
                    }
                default:
                    return new Vanilla();
            }
        }
    }

    public enum Flavor
    {
        Vanilla,
        Strawberry,
        Chocolate
    }
    #endregion

    #region Products -- Ice Cream

    //product interface
    public interface IIceCream
    {

    }

    //concrete products
    public class Strawberry : IIceCream
    {
    }

    public class Chocolate : IIceCream
    {
    }

    public class Vanilla : IIceCream
    {
    }

    #endregion
}
