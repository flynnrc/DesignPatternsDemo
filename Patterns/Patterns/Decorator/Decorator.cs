using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Decorator
{
    public interface IBear
    {
        int AttackDamage { get; set; }
        int Health { get; set; }
        List<string> Commentary { get; set; }
    }

    public class BasicBear : IBear
    {
        public List<string> Commentary { get; set; } = new List<string>();
        public int AttackDamage { get; set; }
        public int Health { get; set; }

        public BasicBear()
        {
            Commentary.Add("Fury");
            Health = 2;
            AttackDamage = 2;
        }
    }

    public class ArmoredBear : IBear
    {
        private IBear _decoratedBear;

        public ArmoredBear(IBear bear)
        {
            _decoratedBear = bear;
            Health = _decoratedBear.Health + 1;
            AttackDamage = _decoratedBear.AttackDamage;
            _decoratedBear.Commentary.ForEach(x => Commentary.Add(x));
            Commentary.Add("It's a bear, with armor.");
        }

        public int AttackDamage { get; set; }
        public int Health { get; set; }
        public List<string> Commentary { get; set; } = new List<string>();
    }
}
