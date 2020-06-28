using System;
using System.Collections.Generic;

namespace Zuul
{
    public class Key : Item
    {
        public Key(string description, int weight) : base (description, weight)
        {
            this.description = description;
            this.weight = weight;
        }


    }

}