using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Fan 1 : ON
            Fan blackpink = new Fan();
            blackpink.Color = "blackpink";
            blackpink.Speed = 2;
            blackpink.On = true;
            Console.WriteLine(blackpink.ToString());

            //Fan 2 : OFF
            Fan bigbang = new Fan();
            bigbang.Color = "yellow";
            bigbang.Speed = 1;
            Console.WriteLine(bigbang.ToString());

            //Fan 3 : default
            Fan quanchung = new Fan();
            Console.WriteLine(quanchung.ToString());
            Console.ReadKey();
        }
    }

    public class Fan
    {
        //data field
        string[] status = { "SLOW", "MEDIUM", "FAST" };
        private int speed = 0;
        private bool on = false;
        private double radius = 5;
        private string color = "blue";

        //Getter and Setter
       public int Speed
        {
            get => speed; set => speed = value;
        }

        public bool On
        {
            get => on; set => on = value;
        }

        public double Radius
        {
            get => radius; set => radius = value;
        }

        public string Color
        {
            get => color; set => color = value;
        }

        public Fan()
        {

        }

        public override string ToString()
        {
            if (on)
            {
                return string.Format("[Fan is on] speed {0} | color {1} | radius {2}", status[speed], color, radius);
            } else
            {
                return string.Format("[Fan is off] radius {0} | color {1}", radius, color);
            }

        }

    }

}
