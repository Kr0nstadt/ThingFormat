using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingFormat.ThingFormats
{
    internal class Presentation : ThingFormat
    {
        public Presentation(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Презентатор";
        }
    }
}
