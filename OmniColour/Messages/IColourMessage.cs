using System.Collections.ObjectModel;
using OmniColour.Decoration.Interfaces;

namespace OmniColour.Messages
{
  /// <summary>
  /// A full message that should be printed to the command line.
  /// May contain multiple blocks of text with multiple decorations.
  /// </summary>
  public interface IColourMessage
  {
    IColourMessage Append(string value);

    IColourMessage Append(IOmniDecoration decoration, string value);
    
    IColourMessage AppendLine(string value);

    IColourMessage AppendLine(IOmniDecoration decoration, string value);

    IColourMessage AppendFormat(string format, params object[] arguments);

    IColourMessage AppendFormat(IOmniDecoration decoration, string format, params object[] arguments);

    Collection<IColourEntry> Build();
    
    IColourMessage Clear();
  }
}
