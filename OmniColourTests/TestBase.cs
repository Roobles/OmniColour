using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniColour;
using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;
using OmniColour.Factories;
using OmniColour.Factories.Interfaces;
using OmniColour.Providers.Interfaces;
using OmniColour.Writers;
using OmniColourTests.Types;

namespace OmniColourTests
{ 
  [TestClass]
  public class TestBase
  {
    internal IOmniColourFactory OmniFactory { get { return OmniColourFactory.Factory; } }

    internal IColourWriter TestWriter { get { return OmniFactory.BuildWriter(); } }

    internal IList<string> TestContents { get { return TestOutputWriter.Contents; } }

    internal IList<OmniColours> TestColours { get { return TestOutputWriter.Colours; } }

    protected void InitializeBase()
    {
      TestColours.Clear();
      TestContents.Clear();
      SetDependencies(OmniColourFactory.IoC);
    }

    internal virtual void SetDependencies(IOmniColourFactoryIoc omniColourIoc)
    {
      omniColourIoc.OutputWriterProviderContrustor = BuildTestProvider;
    }

    private static IOutputWriterProvider BuildTestProvider()
    {
      return new TestOutputWriterProvider();
    }

    internal void AssertEqual(IOmniDecoration a, IOmniDecoration b)
    {
      Assert.IsTrue(AreEqual(a, b));
    }

    internal void AssertEqual(IOmniDecoration a, OmniColours b)
    {
      AssertEqual(a, new OmniDecoration(b));
    }

    internal bool AreEqual(IOmniDecoration a, IOmniDecoration b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;

      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;

      return a.Colour == b.Colour;
    }
  }
}
