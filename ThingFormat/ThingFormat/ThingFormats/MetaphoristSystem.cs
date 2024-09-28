using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingFormat.ThingFormats
{
    internal class MetaphoristSystem : ThingFormat
    {
        public MetaphoristSystem(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Метафорный Системщик";
        }
    }
}
