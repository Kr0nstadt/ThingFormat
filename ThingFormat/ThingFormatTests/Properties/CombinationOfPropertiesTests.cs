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

            Assert.IsTrue(thingFormat is SystemPresenter);// c 13
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

            Assert.IsTrue(thingFormat is SystemPresenter);
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

            Assert.IsTrue(thingFormat is Exeption);
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

            Assert.IsTrue(thingFormat is Exeption);
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

            Assert.IsTrue(thingFormat is ThingFormats.Presentation);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestMS1()
        {
            Analyst analyst = new Analyst(-5);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(-10);
            System system = new System(14);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.MetaphoristSystem);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestPA()
        {
            Analyst analyst = new Analyst(10);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(5);
            System system = new System(-10);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.PresenterAnalyst);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestAP()
        {
            Analyst analyst = new Analyst(10);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(5);
            System system = new System(-17);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.AnalystPresenter);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestP()
        {
            Analyst analyst = new Analyst(10);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(5);
            System system = new System(0);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.Presentation);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestPS()
        {
            Analyst analyst = new Analyst(-4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(10);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.PresenterSystem);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestSP()
        {
            Analyst analyst = new Analyst(-4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(18);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.SystemPresenter);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestSP20()
        {
            Analyst analyst = new Analyst(-4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.SystemPresenter);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestSP15()
        {
            Analyst analyst = new Analyst(-4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(15);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.SystemPresenter);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestPS14()
        {
            Analyst analyst = new Analyst(-4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(14);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.PresenterSystem);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestPS5()
        {
            Analyst analyst = new Analyst(-4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(5);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.PresenterSystem);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestP4()
        {
            Analyst analyst = new Analyst(-4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(4);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.Presentation);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestPMinus5()
        {
            Analyst analyst = new Analyst(4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(-5);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.Presentation);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestPAMinus6()
        {
            Analyst analyst = new Analyst(4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(-6);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.PresenterAnalyst);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestPAMinus15()
        {
            Analyst analyst = new Analyst(4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(-15);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.PresenterAnalyst);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestAPMinus16()
        {
            Analyst analyst = new Analyst(4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(-16);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.AnalystPresenter);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestAPMinus20()
        {
            Analyst analyst = new Analyst(4);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(-20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.AnalystPresenter);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestEx1()
        {
            Analyst analyst = new Analyst(-5);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(-20);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.Exeption);
        }

        [TestMethod()]
        public void ThingFormatConvectorTestEx2()
        {
            Analyst analyst = new Analyst(0);
            Confidence confidence = new Confidence(4);
            Presentation presentation = new Presentation(1);
            System system = new System(0);

            CombinationOfProperties combination = new CombinationOfProperties(analyst, confidence, system, presentation);

            ThingFormats.ThingFormat thingFormat = combination.ThingFormatConvector();

            Assert.IsTrue(thingFormat is ThingFormats.Exeption);
        }
    }
}