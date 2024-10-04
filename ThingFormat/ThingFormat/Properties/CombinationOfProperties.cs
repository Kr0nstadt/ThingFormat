using ThingFormat.ThingFormats;

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
            _diagram = new Diagram(_analyst, _confidence, _system, _presentation);
        }

        public CombinationOfProperties(FileInput fileInput)
        {
            _analyst = fileInput.Analyst;
            _confidence = fileInput.Confidence; ;
            _system = fileInput.System;
            _presentation = fileInput.Presentation;
            _diagram = new Diagram(_analyst, _confidence, _system, _presentation);
        }

        public ThingFormats.ThingFormat ThingFormatConvector()
        {
            ThingFormats.ThingFormat resFormat = null;

            bool isSP = _system.Point <= 20 && _system.Point >= 15;
            bool isPS = _system.Point < 15 && _system.Point >= 5;
            bool isP = _system.Point < 5 && _system.Point >= -5;
            bool isPA = _system.Point < -5 && _system.Point >= -15;
            bool isAP = _system.Point < -15 && _system.Point >= -20;
            bool isNA = (_system.Point < 0 && _analyst.Point < 0) ||
                        (_system.Point == 0 && _analyst.Point == 0);

            int delta = _system.Point - _analyst.Point;

            if (isNA)
            {
                resFormat = new Exeption(_diagram);
            }
            else if (delta >= -4 && delta <= 4)
            {
                resFormat = new ThingFormats.Presentation(_diagram);
            }
            else if (_presentation.Point > 0)
            {
                resFormat = isSP ? new SystemPresenter(_diagram) :
                            isPS ? new PresenterSystem(_diagram) :
                            isP ? new ThingFormats.Presentation(_diagram) :
                            isPA ? new PresenterAnalyst(_diagram) :
                            isAP ? new AnalystPresenter(_diagram) :
                            new Exeption(_diagram);
            }
            else
            {
                resFormat = _system.Point > _analyst.Point ? new MetaphoristSystem(_diagram) : new MetaphoristAnalyst(_diagram);
            }

            if (resFormat is null)
            {
                throw new Exception("Result thing format is null");
            }

            return resFormat;
        }



        private Analyst _analyst;
        private Confidence _confidence;
        private System _system;
        private Presentation _presentation;
        private Diagram _diagram;
    }
}
