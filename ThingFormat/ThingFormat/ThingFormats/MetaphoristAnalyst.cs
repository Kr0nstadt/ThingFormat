using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingFormat.ThingFormats
{
    internal class MetaphoristAnalyst : ThingFormat
    {
        public MetaphoristAnalyst(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Метафорный Аналитик";
        }
    }
}
