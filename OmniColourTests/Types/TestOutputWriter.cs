using System.Collections.Generic;
using System.Collections.ObjectModel;
using OmniColour;
using OmniColour.Environment;
using OmniColour.Writers.Output;

namespace OmniColourTests.Types
{
  internal class TestOutputWriter : OutputWriter
  {
    private readonly List<string> _contents;
    private readonly List<OmniColours> _colours; 

    public Collection<string> Contents { get { return new Collection<string>(_contents); } }

    public Collection<OmniColours> Colours { get { return new Collection<OmniColours>(_colours); } } 

    public TestOutputWriter()
    {
      _contents = new List<string>();
      _colours = new List<OmniColours>();
    }

    public void Clear()
    {
      _contents.Clear();
      _colours.Clear();
    }

    public override CommandLineEnvironments TargetEnvironment
    {
      get { return CommandLineEnvironments.Unknown; }
    }

    protected override void SetColour(OmniColours colour)
    {
      _colours.Add(colour);
    }

    public override void Write(string value)
    {
      if (!string.IsNullOrEmpty(value))
        _contents.Add(value);
    }
  }
}
