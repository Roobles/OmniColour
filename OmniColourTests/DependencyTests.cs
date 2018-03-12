using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniColour.Factories;

namespace OmniColourTests
{
  [TestClass]
  public class DependencyTests
  {
    [TestMethod]
    public void TestStandardFactory()
    {
      var factory = OmniColourFactory.Factory;
      OmniColourFactory.IoC.SetStandard();

      Assert.IsNotNull(factory.BuildWriter());
      Assert.IsNotNull(factory.BuildWriter());
    }
  }
}
