using Pavolle.BES.SettingServer.ClientLib;

namespace Pavolle.BES.SettingServer.UnitTests
{
    public class ServerStatusTests
    {
        [SetUp]
        public void Setup()
        {
            SettingServiceManager.Instance.Initialize("https://localhost:7023", "Unit Test", "Test-App");
        }

        [Test]
        public void TestServerStatus()
        {
            var response = SettingServiceManager.Instance.GetServerStatus();
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.DbStatus);
            Assert.IsTrue(response.ServerStatus);
        }
    }
}