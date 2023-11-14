using Pavolle.BES.SettingServer.ClientLib;

namespace Pavolle.BES.SettingServer.UnitTests
{
    public class ServerStatusTests
    {
        [SetUp]
        public void Setup()
        {
            SettingServiceManager.Instance.Initialize("https://localhost:7023");
        }

        [Test]
        public void TestServerStatus()
        {
            var response = SettingServiceManager.Instance.GetServerStatus();
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.DbStatus == "Ready");
            Assert.IsTrue(response.ServerStatus == "Ready");
        }
    }
}