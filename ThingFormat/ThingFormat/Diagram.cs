using ThingFormat.Properties;

namespace ThingFormat
{
    public class Diagram
    {
        public string DiagramRes => _diagramRes;

        public Diagram(Analyst analyst, Confidence confidence, Properties.System system, Presentation presentation)
        {
            _analyst = analyst;
            _confidence = confidence;
            _system = system;
            _presentation = presentation;

            _diagramRes = CreateDiagram();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string CreateDiagram()
        {
            return "Резудьтат диаграммы";
        }

        private Analyst _analyst;
        private Confidence _confidence;
        private Properties.System _system;
        private Presentation _presentation;
        private string _diagramRes;
    }
}
