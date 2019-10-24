using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.SimpleFactory
{

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
                        return new Strawberry();
                    }
                case Flavor.Strawberry:
                    {
                        return new Chocolate();
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


    public interface IIceCream
    {

    }

    //concretes
    public class Strawberry : IIceCream
    {
    }

    public class Chocolate : IIceCream
    {
    }

    public class Vanilla : IIceCream
    {
    }
}
