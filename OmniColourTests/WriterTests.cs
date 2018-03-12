using System;
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

      var writer = OmniFactory.BuildWriter();
      var message = OmniFactory.BuildMessage();
      var outputWriter = TestWriter;
      var contents = outputWriter.Contents;

      Assert.IsNotNull(message.AppendLine(messageTxt));
      Assert.IsNotNull(writer.Write(message));

      Assert.AreEqual(contents.Count, 1);
      Assert.AreEqual(string.Format("{0}{1}", messageTxt, Environment.NewLine), contents.First());
    }
  }
}
