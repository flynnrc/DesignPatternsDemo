using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.FactoryMethod
{
    //Note: This is demo code only for quick viewing, normally you should put each class in its own file

    //Factory Method
    //Decouples the implementation of a product from its use.
    //Encapsulates object creation.
    //Allows a class to defer instantiation to subclasses. (allows for polymorphism and variation of subclasses)
    //Use Factory Methods when you want to reuse common functionality, but defer instantiation to subclasses
    //To implement, define an IFactory interface with a method that instantiates a type of product and an IProduct interface to define the type of object the factory method should produce

    //In this example, there are several factories that instantiate animals. Each factory encapsulates its own logic for producing the animal. 
    //The concrete factory class determines the instantiation rules not the caller. You can imagine that different factories may have unique rules on how to produce the animal,
    //maybe some animals are seasonal for one region, another produces them randomly, or another is limited to only certain subsets of animal etc... 

    //tips
    //you can use multiple factory methods to fit the level of customization required
    //you can provide some default implementation and re-use some functionality, if you use an abstraction that allows default implementations

    #region Product - Class - Animal

    //this is the product interface, in this case an Animal
    public interface IAnimal
    {
    }

    //concrete animals
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

    #region Creator - Factory - AnimalFactory
    //animal factory contract -- can be an interface or abstract base class
    //defines any factory methods
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
}
