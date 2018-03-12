using System.Collections.Generic;
using OmniColour;
using OmniColour.Environment;
using OmniColour.Writers.Output;

namespace OmniColourTests.Types
{
  internal class TestOutputWriter : OutputWriter
  {
    private static readonly List<string> ContentList;
    private static readonly List<OmniColours> ColourList;

    static TestOutputWriter()
    {
      ContentList = new List<string>();
      ColourList = new List<OmniColours>();
    }

    public static IList<string> Contents { get { return ContentList; } }

    public static IList<OmniColours> Colours { get { return ColourList; } } 
    
    public void Clear()
    {
      ContentList.Clear();
      ColourList.Clear();
    }

    public override CommandLineEnvironments TargetEnvironment
    {
      get { return CommandLineEnvironments.Unknown; }
    }

    protected override void SetColour(OmniColours colour)
    {
      ColourList.Add(colour);
    }

    public override void Write(string value)
    {
      if (!string.IsNullOrEmpty(value))
        ContentList.Add(value);
    }
  }
}
