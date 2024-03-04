using Domain.Entities;

namespace Domain.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CrdData crdData = new CrdData(0, "", "", DateTime.Now, DateTime.Now,0, 0,  "", "" );

            Assert.AreEqual(0, crdData.Id, 0, "Incorrect initialization");
        }
    }
}