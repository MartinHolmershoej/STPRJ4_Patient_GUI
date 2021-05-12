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
            
        }

        [Test]
        public void CheckGatingTrue()
        {
            data = new DTO_Measurement(2, 1, 3, false);
            uut.CheckGating(data);
            Assert.That(data.GatingState, Is.EqualTo(true));
        }
        [Test]
        public void CheckGatingfalse()
        {
            data = new DTO_Measurement(10, 1, 3, true);
            uut.CheckGating(data);
            Assert.That(data.GatingState, Is.EqualTo(false));
        }
    }
}