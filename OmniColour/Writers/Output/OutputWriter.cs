using System;
using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;
using OmniColour.Environment;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Writers.Output
{
  internal abstract class OutputWriter : IOutputWriter
  {
    public void SetDecoration(IOmniDecoration decoration = null)
    {
      decoration = decoration ?? OmniDecoration.None;
      SetColour(decoration.Colour);
    }

    public void ClearDecorations()
    {
      SetDecoration(OmniDecoration.None);
    }

    public virtual void Write(string value)
    {
      if (string.IsNullOrEmpty(value))
        return;

      // TODO: Consider expanding this.
      Console.Write(value);
    }

    #region Abstract Members
    public abstract CommandLineEnvironments TargetEnvironment { get; }

    protected abstract void SetColour(OmniColours colour);
    #endregion
  }
}
