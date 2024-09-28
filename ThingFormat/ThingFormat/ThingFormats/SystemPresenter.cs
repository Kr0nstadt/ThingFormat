using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingFormat.ThingFormats
{
    internal class SystemPresenter : ThingFormat
    {
        public SystemPresenter(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Системный Презентатор";
        }
    }
}
