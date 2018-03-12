using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniColour.Factories;
using OmniColour.Factories.Interfaces;

namespace OmniColourTests
{
  [TestClass]
  public class DependencyTests
  {
    [TestMethod]
    public void TestStandardFactory()
    {
      var factory = (IOmniColourFactory) new OmniColourFactory();
      Assert.IsNotNull(factory.BuildWriter());
      Assert.IsNotNull(factory.BuildWriter());
    }
  }
}
