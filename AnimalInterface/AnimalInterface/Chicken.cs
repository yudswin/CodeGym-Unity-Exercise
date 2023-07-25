using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalInterface
{
    public class Chicken : Animal, Ediable
    {
        public string HowToEat()
        {
            return "Chicken can be fried or boiled";
        }

        public sealed override string MakeSound()
        {
            return "Chicken: cluckk cluck cluckkk!!!";
        }
    }
}
