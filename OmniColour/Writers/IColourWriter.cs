using OmniColour.Decoration.Interfaces;
using OmniColour.Messages;

namespace OmniColour.Writers
{
  /// <summary>
  /// A writer that is capable of writing IColourMessages or inline decorated blocks of text.
  /// </summary>
  public interface IColourWriter
  {
    /// <summary>
    /// Clears all current decorations.
    /// </summary>
    IColourWriter ClearDecoration();

    /// <summary>
    /// Gets the current decoration.
    /// </summary>
    IOmniDecoration GetDecoration();

    /// <summary>
    /// Sets the current decoration on the command line.
    /// All future direct blocks written will be decorated with this value.
    /// </summary>
    /// <param name="decoration">The decoration values to apply.</param>
    IColourWriter SetDecoration(IOmniDecoration decoration);

    /// <summary>
    /// Writes an IColourMessage to the command line.
    /// </summary>
    /// <param name="message">The message to be written.</param>
    IColourMessage Write(IColourMessage message);

    /// <summary>
    /// Writes a single block of text to the command line.
    /// This text will be decorated by the last invocation of SetDecoration.
    /// </summary>
    /// <param name="value">The block of text to be written.</param>
    IColourWriter Write(string value);

    /// <summary>
    /// Writes a single block of text to the command line.  Uses the colour provided.
    /// </summary>
    /// <param name="colour">Colour to decorate with.</param>
    /// <param name="value">The block of text to be written.</param>
    IColourWriter Write(OmniColours colour, string value);

    /// <summary>
    /// Writes a formatted block of text to the command line.
    /// This text will be decorated by the last invocation of SetDecoration.
    /// </summary>
    /// <param name="format">A format string.</param>
    /// <param name="arguments">Parameters to be provided to the format string.</param>
    IColourWriter WriteFormat(string format, params object[] arguments);

    /// <summary>
    /// Writes a formatted block of text to the command line.  Uses the colour provided.
    /// </summary>
    /// <param name="colour">Colour to decorate with.</param>
    /// <param name="format">A format string.</param>
    /// <param name="arguments">Parameters to be provided to the format string.</param>
    IColourWriter WriteFormat(OmniColours colour, string format, params object[] arguments);

    /// <summary>
    /// Writes a single line to the command line.
    /// This text will be decorated by the last invocation of SetDecoration.
    /// </summary>
    /// <param name="line">Line to be written.</param>
    IColourWriter WriteLine(string line);

    /// <summary>
    /// Writes a single line to the command line.  Uses the colour provided.
    /// </summary>
    /// <param name="colour">Colour to decorate with.</param>
    /// <param name="line">Line to be written.</param>
    IColourWriter WriteLine(OmniColours colour, string line);
  }
}
