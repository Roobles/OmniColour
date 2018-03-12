using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniColour;
using OmniColour.Decoration;

namespace OmniColourTests
{
  [TestClass]
  public class WriterTests : TestBase
  {
    [TestInitialize]
    public void InitiatalizeTest()
    {
      InitializeBase();
    }

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
      const string colorText = "Hello, world.";
      const string blankText = "Goodbye, world.";
      const OmniColours color = OmniColours.Blue;
      
      var decoration = new OmniDecoration(color);
      var writer = TestWriter;
      var message = OmniFactory.BuildMessage();

      Assert.IsNotNull(message.AppendLine(decoration, colorText));
      Assert.IsNotNull(message.AppendLine(blankText));
      Assert.IsNotNull(writer.Write(message));

      Assert.AreEqual(TestContents.Count, 2);
      Assert.AreEqual(TestColours.Count, 2);
      Assert.AreEqual(TestColours.First(), color);
    }
  }
}
