using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingFormat.Properties
{
    public class Properties
    {
        public int Point {  get; }
        public void AddPoints(int points) => _point += points;

        public Properties()
        {
            Point = 0;
        }

        public Properties(int point)
        {
            Point = point;
        }

        private int _point; 
    }
}
