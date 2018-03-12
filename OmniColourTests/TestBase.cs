using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniColour;
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
    private readonly IOmniColourFactory _omniFactory;

    internal IOmniColourFactory OmniFactory { get { return _omniFactory; } }

    internal IColourWriter TestWriter { get { return OmniFactory.BuildWriter(); } }

    internal IList<string> TestContents { get { return TestOutputWriter.Contents; } }

    internal IList<OmniColours> TestColours { get { return TestOutputWriter.Colours; } } 
    
    public TestBase()
    {
      _omniFactory = BuildOmniFactory();
    }

    internal IOmniColourFactory BuildOmniFactory()
    {
      SetDependencies(OmniColourFactory.IoC);

      return OmniColourFactory.Factory;
    }

    internal virtual void SetDependencies(IOmniColourFactoryIoc omniColourIoc)
    {
      omniColourIoc.OutputWriterProviderContrustor = BuildTestProvider;
    }

    private IOutputWriterProvider BuildTestProvider()
    {
      return new TestOutputWriterProvider();
    }
  }
}
