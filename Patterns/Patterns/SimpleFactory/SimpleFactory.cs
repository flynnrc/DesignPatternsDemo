using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.SimpleFactory
{

    //Simple Factory (SF):
    //SF encapsulates object creation
    //SF is not a true pattern, but it's a precursor to complex factories, and a DRY principle code construct
    //One drawback of SF is that object creation is dependent on the callers information, in simple cases this is okay
    //Pitfalls: Code changes are required to stay in sync as different objects are added, often seen as a growing switch stmt
    //In some cases the SF may become too complicated, which indicates that it may be time to swap it for a more complex factory
    //The factory method pattern completely decouples object creation and adds polymorphism. SF only handles creation.

    //Implementation:
    //Typically SF has a factory that accepts input to help decide which object to create
    //There is also a product Interface to set a contract for what the factory ultimately produces

    //IceCreamFactory Example: 
    //The ice cream factory accepts an enum to help determine what type of ice cream product to make.
    //Any ice cream can be produced, so long as it's a part of the factory and fulfills the contract

    #region Factory -- Ice Cream Factory
    public class SimpleIceCreamFactory
    {
        public static IIceCream Create(Flavor type)
        {
            //This is a simple case so it works great!
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
            //Try to imagine a situation where the cases become complex
            //or the number of cases grows too large
            //In those situation this could become unwieldy 
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
