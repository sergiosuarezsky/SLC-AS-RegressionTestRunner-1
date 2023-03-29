namespace RegressionTestRunner.AutomationScripts.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using RegressionTestRunner.AutomationScripts;
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Messages.Advanced;
    using System;
    using System.IO;

    [TestClass()]
    public class AutomationScriptHelperTests
    {
        [TestMethod()]
        public void RetrieveScriptsTest_RootDirectory()
        {
            Mock<IEngine> mockedEngine = new Mock<IEngine>();
            mockedEngine.Setup(x => x.SendSLNetSingleResponseMessage(It.IsAny<GetAutomationInfoMessage>())).Returns(GetResponse());

            var rootDirectory = AutomationScriptHelper.RetrieveScripts(mockedEngine.Object, String.Empty);

            Assert.AreEqual(20, rootDirectory.Directories.Count);
            Assert.AreEqual(104, rootDirectory.Scripts.Count);
        }

        [TestMethod()]
        public void RetrieveScriptsTest_YleDirectory()
        {
            Mock<IEngine> mockedEngine = new Mock<IEngine>();
            mockedEngine.Setup(x => x.SendSLNetSingleResponseMessage(It.IsAny<GetAutomationInfoMessage>())).Returns(GetResponse());

            var rootDirectory = AutomationScriptHelper.RetrieveScripts(mockedEngine.Object, "YLE");

            Assert.AreEqual(7, rootDirectory.Directories.Count);
            Assert.AreEqual(2, rootDirectory.Scripts.Count);
        }

        private GetAutomationInfoResponseMessage GetResponse()
        {
            string serializedResponse = File.ReadAllText(@"..\..\AutomationInfoResponse.json");
            return JsonConvert.DeserializeObject<GetAutomationInfoResponseMessage>(serializedResponse);
        }
    }
}