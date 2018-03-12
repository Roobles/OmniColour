using System.Collections.Generic;
using OmniColour;
using OmniColour.Providers.Interfaces;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColourTests.Types
{
  internal class TestOutputWriterProvider : IOutputWriterProvider
  {
    private readonly TestOutputWriter _testWriter;

    public TestOutputWriter TestWriter { get { return _testWriter; } }

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
