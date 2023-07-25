using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalInterface
{
    internal class Apple : Fruit
    {
        public sealed override string HowToEat()
        {
            return "Apple can make pie, juice or peel to eat!";
        }
    }
}
