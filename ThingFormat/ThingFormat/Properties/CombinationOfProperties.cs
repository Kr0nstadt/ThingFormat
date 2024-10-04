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

            int fmPoints =
                Math.Abs(
                    Math.Max(Math.Abs(_system.Point), Math.Abs(_analyst.Point))) -
                    Math.Abs(Math.Min(Math.Abs(_system.Point), Math.Abs(_analyst.Point))
                );


            #region ЕСЛИ П > 0 и С > 0 и А > 0
            bool isPSAGreaterZero = _presentation.Point >= 0 && _system.Point > 0 && _analyst.Point > 0;
            //ФМ = (20 ; +15) - СП - тут П => 0
            //ЕСЛИ П>0 и С > 0 и А < =0  - CП
            bool isSP = (isPSAGreaterZero && fmPoints < 20 && fmPoints >= 15) ||
                (_presentation.Point > 0 && _system.Point > 0 && _analyst.Point <= 0);
            //ФМ = (+14 ; +5] - ПC
            bool isPS = isPSAGreaterZero && fmPoints < 14 && fmPoints >= 5;
            //ФМ =(+4 ; -5] - П
            bool isP = isPSAGreaterZero && fmPoints <= 4 && fmPoints >= -5;
            //ФМ = (-6; -15) - ПА
            bool isPA = isPSAGreaterZero && fmPoints < -6 && fmPoints > -15;
            //ФМ = (-16; -20) - АП - тут П => 0
            //ЕСЛИ П>0 и С <= 0 и А > 0  - АП
            bool isAP = (isPSAGreaterZero && fmPoints < -16 && fmPoints > -20) ||
                (_presentation.Point > 0 && _system.Point <= 0 && _analyst.Point > 0);
            #endregion

            //ЕСЛИ П>0 и С=0 и А=0 - NA
            //ЕСЛИ П<0 и ЕСЛИ С=А=0 - NA
            bool isNA = (_system.Point == 0 && _analyst.Point == 0);

            #region ЕСЛИ П<0
            bool isPLessZero = _presentation.Point < 0;
            //ЕСЛИ |С| > |A| - МС (мет. сист.)
            bool isMS = isPLessZero && Math.Abs(_system.Point) > Math.Abs(_analyst.Point);
            //ЕСЛИ | С | < | A | -МА(мет.аналит.)
            bool isMA = isPLessZero && Math.Abs(_system.Point) < Math.Abs(_analyst.Point);
            #endregion

            #region ФМ - 0
            bool isFmEqualZero = fmPoints == 0;
            //Если ФМ = 0 и при этом 0 <= П <= 10 - “Недобросовестно”
            bool isUnscrupulous = isFmEqualZero && _presentation.Point >= 0 && _presentation.Point <= 10;//это нигде не юзается

            #region Если ФМ = 0 и П < 0
            bool isFmEqZeroAndPLessZero = isFmEqualZero && _presentation.Point < 0;
            //ЕСЛИ |С| > |A| - МС (мет. сист.)
            isMS = isFmEqZeroAndPLessZero && Math.Abs(_system.Point) > Math.Abs(_analyst.Point);
            //ЕСЛИ |С| <= |A| - МА (мет. аналит.)
            isMA = isFmEqZeroAndPLessZero && Math.Abs(_system.Point) <= Math.Abs(_analyst.Point);
            #endregion

            //Если ФМ=0 и П>10 - Презентатор
            isP = isFmEqualZero && _presentation.Point > 10;
            #endregion


            #region определение ФМ
            Exeption exeption = isNA ? new(_diagram) : null;
            PresenterAnalyst presenterAnalyst = isPA ? new(_diagram) : null;
            MetaphoristSystem metaphoristSystem = isMS ? new(_diagram) : null;
            AnalystPresenter analystPresenter = isAP ? new(_diagram) : null;
            ThingFormats.Presentation presentation = isP ? new(_diagram) : null;
            SystemPresenter systemPresenter = isSP ? new(_diagram) : null;
            MetaphoristAnalyst metaphoristAnalyst = isMA ? new(_diagram) : null;
            PresenterSystem presentationSystem = isPS ? new(_diagram) : null;
            

            List<ThingFormats.ThingFormat> thingFormatsList = new List<ThingFormats.ThingFormat>(8);
            thingFormatsList.Add(exeption);
            thingFormatsList.Add(presenterAnalyst);
            thingFormatsList.Add(metaphoristSystem);
            thingFormatsList.Add(analystPresenter);
            thingFormatsList.Add(presentation);
            thingFormatsList.Add(systemPresenter);
            thingFormatsList.Add(metaphoristAnalyst);
            thingFormatsList.Add(presentationSystem);
            

            int countOfNotNullFormats = 0;

            foreach (var format in thingFormatsList)
            {
                if (format is not null)
                {
                    countOfNotNullFormats++;
                    resFormat = format;
                }
            }
            #endregion

            if (countOfNotNullFormats > 1)
                throw new Exception("Count of thing formats greater then 1");

            return resFormat;
        }



        private Analyst _analyst;
        private Confidence _confidence;
        private System _system;
        private Presentation _presentation;
        private Diagram _diagram;
    }
}
