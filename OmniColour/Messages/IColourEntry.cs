using OmniColour.Decoration;

namespace OmniColour.Messages
{
  public interface IColourEntry
  {
    IOmniDecoration Decorations { get; }

    string Message { get; }
  }
}
