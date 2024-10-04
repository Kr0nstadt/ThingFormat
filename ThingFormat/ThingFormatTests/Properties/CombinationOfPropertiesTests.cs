using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThingFormat.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingFormat.ThingFormats;

namespace ThingFormat.Properties.Tests
{
    [TestClass()]
    public class CombinationOfPropertiesTests
    {
        [TestMethod()]
        public void ThingFormatConvectorTestNotNull()
        {
            Analyst analyst = new Analyst();
            Confidence confidence = new Confidence();
            Presentation presentation = new Presentation();
            System system = new System();

            CombinationOfProperties combination = new CombinationOfProperties(analyst,confidence,system,presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            //Assert.IsTrue(thingFormat is MetaphoristSystem);
            Assert.IsNotNull(thingFormat);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestSP1()
        {
            Analyst analyst = new Analyst(4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(2);
            System system = new System(20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is SystemPresenter);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestSP2()
        {
            Analyst analyst = new Analyst(0);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(2);
            System system = new System(20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is SystemPresenter);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestSP3()
        {
            Analyst analyst = new Analyst(-3);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(2);
            System system = new System(20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is SystemPresenter);
        }
        [TestMethod()]
        public void ThingFormatConvectorTestSP4()
        {
            Analyst analyst = new Analyst(-6);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(2);
            System system = new System(20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is SystemPresenter);//аналитика отр особый случай
        }

        [TestMethod()]
        public void ThingFormatConvectorTestPS1()
        {
            Analyst analyst = new Analyst(7);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(2);
            System system = new System(20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is PresenterSystem);// c 13
        }
         
        [TestMethod()]
        public void ThingFormatConvectorTestPS2()
        {
            Analyst analyst = new Analyst(15);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(2);
            System system = new System(20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is PresenterSystem);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestP1()
        {
            Analyst analyst = new Analyst(0);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(12);
            System system = new System(0);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is Presentation);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestExp()
        {
            Analyst analyst = new Analyst(0);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(2);
            System system = new System(0);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is Exception);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestMS()
        {
            Analyst analyst = new Analyst(2);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(0);
            System system = new System(13);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is MetaphoristSystem);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestMA1()
        {
            Analyst analyst = new Analyst(1);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(-10);
            System system = new System(1);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is MetaphoristAnalyst);//74st A==S
        }
    }
}