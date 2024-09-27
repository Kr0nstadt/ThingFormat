namespace ThingFormat.Properties
{
    public class CombinationOfProperties
    {
        public CombinationOfProperties(Analyst analyst, Confidence confidence, System system, Presentation presentation)
        {
            _analyst = analyst;
            _confidence = confidence;
            _system = system;
            _presentation = presentation;
        }

        public CombinationOfProperties(FileInput fileInput)
        {
            _analyst = new Analyst(fileInput.GetAnalyst());
            _confidence = new Confidence(fileInput.GetConfidence()); ;
            _system = new System(fileInput.GetSystem()); ;
            _presentation = new Presentation(fileInput.GetPresentation()); ;
        }

        /// <summary>
        /// 
        /// </summary>
        //public ThingFormat ThingFormatConvector() { }



        private Analyst _analyst;
        private Confidence _confidence;
        private System _system;
        private Presentation _presentation;
        private Diagram _diagram;
    }
}
