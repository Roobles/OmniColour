using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniColourTests
{
  [TestClass]
  public class WriterTests : TestBase
  {
    [TestMethod]
    public void TestSimpleWrite()
    {
      const string messageTxt = "Hello, world.";

      var writer = TestWriter;
      var message = OmniFactory.BuildMessage();

      Assert.IsNotNull(message.AppendLine(messageTxt));
      Assert.IsNotNull(writer.Write(message));

      if (TestContents.Count < 1)
        Debugger.Launch();

      Assert.AreEqual(TestContents.Count, 1);
      Assert.AreEqual(string.Format("{0}{1}", messageTxt, Environment.NewLine), TestContents.First());
    }

    [TestMethod]
    public void TestColourWrite()
    {
      
    }
  }
}
