using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingFormat.ThingFormats
{
    internal class Exeption : ThingFormat
    {
        public Exeption(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Тест пройден некоректно и бессовестно";
        }
    }
}
