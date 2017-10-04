using NUnit.Framework;
using ShortBook.Server.Controllers;

namespace ShortBook.Server.Tests
{
    [TestFixture]
    public class ValuesControllerTests
    {
        [Test]
        public void GetTest()
        {
            ValuesController vc = new ValuesController();
            Assert.AreEqual("value", vc.Get(1));
        }
    }
}
