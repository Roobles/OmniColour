using OmniColour.Decoration;
using OmniColour.Environment;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Writers.Output
{
  public class NullOutputWriter : INullOutputWriter
  {
    public void SetDecoration(IOmniDecoration decoration)
    {
    }

    public void ClearDecorations()
    {
    }

    public void Write(string value)
    {
    }

    public CommandLineEnvironments TargetEnvironment { get {return CommandLineEnvironments.Unknown; } }
  }
}
