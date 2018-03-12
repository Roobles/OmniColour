using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniColour.Factories;
using OmniColour.Factories.Interfaces;
using OmniColour.Providers.Interfaces;
using OmniColourTests.Types;

namespace OmniColourTests
{
  [TestClass]
  internal class TestBase
  {
    private IOmniColourFactory _omniFactory;

    protected IOmniColourFactory OmniFactory
    {
      get { return _omniFactory ?? (_omniFactory = BuildOmniFactory()); }
    }

    protected virtual IOmniColourFactory BuildOmniFactory()
    {
      var factory = new OmniColourFactory();
      SetDependencies(factory);

      return factory;
    }

    protected virtual void SetDependencies(IOmniColourFactoryIoc omniColourIoc)
    {
      omniColourIoc.OutputWriterProviderContrustor = BuildTestProvider;
    }

    private static IOutputWriterProvider BuildTestProvider()
    {
      return new TestOutputWriterProvider();
    }
  }
}
