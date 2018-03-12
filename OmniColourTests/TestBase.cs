using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniColour.Factories;
using OmniColour.Factories.Interfaces;
using OmniColour.Providers.Interfaces;
using OmniColourTests.Types;

namespace OmniColourTests
{
  [TestClass]
  public class TestBase
  {
    private IOmniColourFactory _omniFactory;

    internal IOmniColourFactory OmniFactory
    {
      get { return _omniFactory ?? (_omniFactory = BuildOmniFactory()); }
    }

    internal TestOutputWriterProvider TestProvider { get; private set; }

    internal TestOutputWriter TestWriter
    {
      get { return TestProvider.TestWriter; }
    }

    internal virtual IOmniColourFactory BuildOmniFactory()
    {
      var factory = new OmniColourFactory();
      SetDependencies(factory);

      return factory;
    }

    internal virtual void SetDependencies(IOmniColourFactoryIoc omniColourIoc)
    {
      omniColourIoc.OutputWriterProviderContrustor = BuildTestProvider;
    }

    private IOutputWriterProvider BuildTestProvider()
    {
      return (TestProvider = new TestOutputWriterProvider());
    }
  }
}
