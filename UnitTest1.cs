using System.ComponentModel.Design.Serialization;

namespace monitor
{
    public class Tests : monitor_avi
    {
        //[SetUp]
        // public void Setup()
        // {
        // }

        [Test]
        public void Test1()
        {
            meramethod("igccservice");
        }
        [Test]
        public void Test2()
        {
            meramethod3("W32TIME");
        }
        [Test]
        public void Test3()
        {
            meramethod4("W32TIME");
        }
        [Test]
        public void Test4()
        {
            meramethod2();
        }
    }
}