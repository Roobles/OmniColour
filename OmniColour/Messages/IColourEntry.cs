using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;

namespace OmniColour.Messages
{
  public interface IColourEntry
  {
    IOmniDecoration Decorations { get; }

    string Message { get; }
  }
}
