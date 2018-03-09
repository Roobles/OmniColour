using OmniColour.Decoration;
using OmniColour.Environment;

namespace OmniColour.Writers.Output.Interfaces
{
  internal interface IOutputWriter
  {
    void SetDecoration(IOmniDecoration decoration);

    void ClearDecorations();

    void Write(string value);

    CommandLineEnvironments TargetEnvironment { get; }
  }
}
