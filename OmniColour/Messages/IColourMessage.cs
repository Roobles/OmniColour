using System.Collections.Generic;
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
    /// <summary>
    /// Appends another message.
    /// </summary>
    /// <param name="message">Message to append.</param>
    IColourMessage Append(IColourMessage message);

    /// <summary>
    /// Appends an enumeration of Colour Entries.
    /// </summary>
    /// <param name="entries">Colour Entries to append.</param>
    IColourMessage Append(IEnumerable<IColourEntry> entries);

    /// <summary>
    /// Appends a block of text, using the current decoration.
    /// </summary>
    /// <param name="value">Text to append.</param>
    IColourMessage Append(string value);

    /// <summary>
    /// Appends a block of text, using the specified decoration.
    /// </summary>
    /// <param name="decoration">Decoration to apply.</param>
    /// <param name="value">Text to append.</param>
    IColourMessage Append(IOmniDecoration decoration, string value);

    /// <summary>
    /// Appends a block of text, using the colour specified.
    /// </summary>
    /// <param name="colour">Colour to apply.</param>
    /// <param name="value">Text to append.</param>
    /// <returns></returns>
    IColourMessage Append(OmniColours colour, string value);
    
    /// <summary>
    /// Appends a line of text, using the current decoration.
    /// </summary>
    /// <param name="value">Line to append.</param>
    IColourMessage AppendLine(string value);

    /// <summary>
    /// Appends a line of text, using the specified decoration.
    /// </summary>
    /// <param name="decoration">Decoration to apply.</param>
    /// <param name="value">Line to append.</param>
    IColourMessage AppendLine(IOmniDecoration decoration, string value);

    /// <summary>
    /// Appends a line of text, using the colour specified
    /// </summary>
    /// <param name="colour">Colour to apply.</param>
    /// <param name="value">Line to append.</param>
    IColourMessage AppendLine(OmniColours colour, string value);

    /// <summary>
    /// Appends a formatted block of text, using the current decoration.
    /// </summary>
    /// <param name="format">A format string.</param>
    /// <param name="arguments">Parameters to be provided to the format string.</param>
    IColourMessage AppendFormat(string format, params object[] arguments);

    /// <summary>
    /// Appends a formatted block of text, using the specified decoration.
    /// </summary>
    /// <param name="decoration">Decoration to apply.</param>
    /// <param name="format">A format string.</param>
    /// <param name="arguments">Parameters to be provided to the format string.</param>
    IColourMessage AppendFormat(IOmniDecoration decoration, string format, params object[] arguments);

    /// <summary>
    /// Appends a formatted block of text, using the specified colour.
    /// </summary>
    /// <param name="colour">Colour to apply.</param>
    /// <param name="format">A format string.</param>
    /// <param name="arguments">Parameters to be provided to the format string.</param>
    IColourMessage AppendFormat(OmniColours colour, string format, params object[] arguments);

    /// <summary>
    /// Appends a line break.
    /// </summary>
    IColourMessage Break();

    /// <summary>
    /// Builds the current set of messages to be printed to command line.
    /// </summary>
    Collection<IColourEntry> Build();
    
    /// <summary>
    /// Clears all messages and decorations.
    /// </summary>
    IColourMessage Clear();

    /// <summary>
    /// Gets the current decoration.
    /// </summary>
    IOmniDecoration GetDecoration();

    /// <summary>
    /// Sets the current decoration.
    /// </summary>
    /// <param name="decoration">Decoration to apply.</param>
    IColourMessage SetDecoration(IOmniDecoration decoration);
  }
}
