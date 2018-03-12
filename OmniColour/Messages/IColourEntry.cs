using OmniColour.Decoration.Interfaces;

namespace OmniColour.Messages
{
  /// <summary>
  /// A segment of an IColourMessage.
  /// A pairing of an IOmninDeoration with the text it should be decorating.
  /// </summary>
  public interface IColourEntry
  {
    IOmniDecoration Decorations { get; }

    string Message { get; }
  }
}
