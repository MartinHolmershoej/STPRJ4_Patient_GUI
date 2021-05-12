using DTO;
using Logic_Layer;
using NUnit.Framework;

namespace Patient_GUI_Test
{
    public class AlarmTest
    {
        private Alarm uut;
        private DTO_Measurement data;


        [SetUp]
        public void Setup()
        {
            uut = new Alarm();
            data = new DTO_Measurement(2,1,3,false);
        }

        [Test]
        public void CheckGatingTrue()
        {
            data.GatingState = false;
            data.GatingLowerValue = 1;
            data.GatingUpperValue = 3;
            data.MeasurementData = 2;
            uut.CheckGating(data);
            Assert.That(data.GatingState, Is.EqualTo(true));
        }
        [Test]
        public void CheckGatingfalse()
        {
            data.GatingState = true;
            data.GatingLowerValue = 1;
            data.GatingUpperValue = 3;
            data.MeasurementData = 10;
            uut.CheckGating(data);
            Assert.That(data.GatingState, Is.EqualTo(false));
        }

        [Test]
        public void DontCangeState()
        {
            data.GatingState = true;
            data.GatingLowerValue = 1;
            data.GatingUpperValue = 3;
            data.MeasurementData = 10;
            Assert.That(data.GatingState, Is.EqualTo(true));
        }

        [Test]
        public void CheckGatingDIBH()
        {
            data.GatingState = false;
            data.GatingLowerValue = 1;
            data.GatingUpperValue = 3;
            data.MeasurementData = 2;
            uut.CheckGating(data);
            uut.CheckGating(data);
            uut.CheckGating(data);
            uut.CheckGating(data);
            Assert.That(data.GatingState, Is.EqualTo(true));
        }
    }
}