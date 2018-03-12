using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniColour;
using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;
using OmniColour.Messages;

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
      const string colourText = "Hello, world.";
      const string blankText = "Goodbye, world.";
      const OmniColours colour = OmniColours.Blue;
      
      var decoration = new OmniDecoration(colour);
      var writer = TestWriter;
      var message = OmniFactory.BuildMessage();

      Assert.IsNotNull(message.AppendLine(decoration, colourText));
      Assert.IsNotNull(message.AppendLine(blankText));
      Assert.IsNotNull(writer.Write(message));

      Assert.AreEqual(TestContents.Count, 2);
      Assert.AreEqual(TestColours.First(), colour);
    }

    [TestMethod]
    public void TestColourClearing()
    {
      const OmniColours colour = OmniColours.BrightCyan;
      var initialColour = TestWriter.GetDecoration();
      
      TestWriter.SetDecoration(new OmniDecoration(colour));
      
      TestWriter.Write("Test01");
      AssertLastColour(colour);

      TestWriter.Write("Test02");
      AssertLastColour(colour);
      
      TestWriter.ClearDecoration();
      AssertLastColour(initialColour);

      TestWriter.Write(colour, "Test03");
      AssertLastColour(initialColour);

      TestWriter.WriteLine("Test04");
      AssertLastColour(initialColour);

      var message = new ColourMessage();
      message.SetDecoration(new OmniDecoration(colour));
      message.AppendLine("Test05");
      TestWriter.Write(message);

      AssertEqual(initialColour, TestColours.Last());
    }

    protected void AssertLastColour(IOmniDecoration decoration)
    {
      AssertEqual(decoration, TestColours.Last());
    }

    protected void AssertLastColour(OmniColours colour)
    {
      Assert.AreEqual(colour, TestColours.Last());
    }
  }
}
