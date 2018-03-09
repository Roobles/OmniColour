using OmniColour.Decoration;

namespace OmniColour.Messages
{
  internal class ColourEntry : IColourEntry
  {
    public IOmniDecoration Decorations { get; private set; }
    
    public string Message { get; private set; }

    public ColourEntry(string message, IOmniDecoration decoration = null)
    {
      Message = message;
      Decorations = decoration ?? OmniDecoration.None;
    }
  }
}
