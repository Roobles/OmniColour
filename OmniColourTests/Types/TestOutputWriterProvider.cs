using OmniColour.Providers.Interfaces;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColourTests.Types
{
  internal class TestOutputWriterProvider : IOutputWriterProvider
  {
    private readonly IOutputWriter _testWriter;

    protected IOutputWriter TestWriter { get { return _testWriter; } }

    public TestOutputWriterProvider()
    {
      _testWriter = new TestOutputWriter();
    }

    public IOutputWriter GetOutputWriter()
    {
      return TestWriter;
    }
  }
}
