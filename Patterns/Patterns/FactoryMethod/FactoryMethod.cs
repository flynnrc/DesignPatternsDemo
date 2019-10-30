using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.FactoryMethod
{
    //Note: This is demo code only for quick viewing, normally you should put each class in its own file

    //Factory Method:
    //Decouples the implementation of a product from its use and Encapsulates object creation.
    //Allows a class to defer instantiation to subclasses. (allows for polymorphism and variation of subclasses)
    //Use Factory Methods when you want to reuse common functionality, but also defer some instantiation to subclasses.

    //Implementation: 
    //Define an IProduct interface that defines the type of object that the factory method should produce
    //Define an IFactory interface that contains an overridable factory method that ultimately returns an IProduct 

    //In this example, there are several factories that instantiate animals. 
    //Each factory encapsulates its own logic for instantiating an animal. 
    //The concrete factory class determines the instantiation rules not the caller. 
    //Imagine that different concrete factories have unique rules to determine which type of IAnimal to produce...
    //Imagine that some factories produce animals according to the season, some produce them based on environment, and some are totally random
    //The factories independently manage their own requirements (the "how") save for the one restriction, to ultimately produce an IAnimal

    //Tips
    //You can use multiple factory methods to fit the level of customization required 
    //You can provide some default implementation with the option to override, so common elements are re-usable

    #region IAnimalFactory and Concrete Factories (Creators)
    //animal factory contract -- can be an interface or abstract base class, optionally some default implementation
    //in this case, the interface declares GetAnimal(), which is the factory method that can be varied by concrete
    public interface IAnimalFactory
    {
        IAnimal GetAnimal();
    }

    //concrete factories, implement the factory method(s)
    public class FreshWaterAnimalFactory : IAnimalFactory
    {
        //some additional logic

        public IAnimal GetAnimal()
        {
            //some additional logic
            return new Frog();
        }
    }

    public class HouseHoldAnimalFactory : IAnimalFactory
    {
        //some additional logic

        public IAnimal GetAnimal()
        {
            //some additional logic
            return new Dog();
        }
    }

    public class WoodlandCreatureAnimalFactory : IAnimalFactory
    {
        //some additional logic

        public IAnimal GetAnimal()
        {
            //some additional logic
            return new Rabbit();
        }
    }

    #endregion

    #region IAnimal and Concrete Animals (Product)

    //Defines IAnimal, concrete Factory Methods will produce IAnimals
    public interface IAnimal
    {
    }

    //Concrete Animals, which implement IAnimal
    public class Dog : IAnimal
    {

    }

    public class Cat : IAnimal
    {

    }

    public class HoneyBadger : IAnimal
    {
        //HoneyBadger don't care
    }

    public class Rabbit : IAnimal
    {

    }

    public class Frog : IAnimal
    {
    }

    public class Fish : IAnimal
    {
    }

    public class Eel : IAnimal
    {

    }
    #endregion
}
