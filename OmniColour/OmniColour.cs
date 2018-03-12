using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;
using OmniColour.Factories;
using OmniColour.Messages;
using OmniColour.Writers;

namespace OmniColour
{
  /// <summary>
  /// Main entry point into the OmniColour library.
  /// </summary>
  public static class Colour
  {
    private static readonly IColourWriter ColourWriter;

    /// <summary>
    /// Handle to the main OmniColour writer.
    /// </summary>
    public static IColourWriter Writer { get { return ColourWriter; } }

    /// <summary>
    /// Handle to a new instance of an IColourMessage.
    /// </summary>
    public static IColourMessage Message { get { return OmniColourFactory.Factory.BuildMessage(); } }

    static Colour()
    {
      ColourWriter = OmniColourFactory.Factory.BuildWriter();
    }

    /// <summary>
    /// Default / reset decoration.
    /// </summary>
    public static IOmniDecoration None { get { return OmniDecoration.None; } }

    /// <summary>
    /// Instantiates a new instance of an IOmniDecoration.
    /// </summary>
    /// <param name="colour">The colour of the decoration.</param>
    public static IOmniDecoration Decoration(OmniColours colour)
    {
      return new OmniDecoration(colour);
    }

    /// <summary>
    /// Clears all current decorations.
    /// </summary>
    public static IColourWriter ClearDecoration()
    {
      return Writer.ClearDecoration();  
    }

    /// <summary>
    /// Sets the current decoration on the command line.
    /// All future direct blocks written will be decorated with this value.
    /// </summary>
    /// <param name="decoration">The decoration values to apply.</param>
    public static IColourWriter SetDecoration(IOmniDecoration decoration)
    {
      return Writer.SetDecoration(decoration);
    }

    /// <summary>
    /// Writes an IColourMessage to the command line.
    /// </summary>
    /// <param name="message">The message to be written.</param>
    public static IColourMessage Write(IColourMessage message)
    {
      return Writer.Write(message);
    }

    /// <summary>
    /// Writes a single block of text to the command line.
    /// This text will be decorated by the last invocation of SetDecoration.
    /// </summary>
    /// <param name="value">The block of text to be written.</param>
    public static IColourWriter Write(string value)
    {
      return Writer.WriteFormat(value);
    }

    /// <summary>
    /// Writes a single block of text to the command line.  Uses the colour provided.
    /// </summary>
    /// <param name="colour">Colour to decorate with.</param>
    /// <param name="value">The block of text to be written.</param>
    public static IColourWriter Write(OmniColours colour, string value)
    {
      return Writer.Write(colour, value);
    }

    /// <summary>
    /// Writes a formatted block of text to the command line.
    /// This text will be decorated by the last invocation of SetDecoration.
    /// </summary>
    /// <param name="format">A format string.</param>
    /// <param name="arguments">Parameters to be provided to the format string.</param>
    public static IColourWriter WriteFormat(string format, params object[] arguments)
    {
      return Writer.WriteFormat(format, arguments);
    }

    /// <summary>
    /// Writes a formatted block of text to the command line.  Uses the colour provided.
    /// </summary>
    /// <param name="colour">Colour to decorate with.</param>
    /// <param name="format">A format string.</param>
    /// <param name="arguments">Parameters to be provided to the format string.</param>
    public static IColourWriter WriteFormat(OmniColours colour, string format, params object[] arguments)
    {
      return Writer.WriteFormat(colour, format, arguments);
    }

    /// <summary>
    /// Writes a single line to the command line.
    /// This text will be decorated by the last invocation of SetDecoration.
    /// </summary>
    /// <param name="line">Line to be written.</param>
    public static IColourWriter WriteLine(string line)
    {
      return Writer.WriteLine(line);
    }

    /// <summary>
    /// Writes a single line to the command line.  Uses the colour provided.
    /// </summary>
    /// <param name="colour">Colour to decorate with.</param>
    /// <param name="line">Line to be written.</param>
    public static IColourWriter WriteLine(OmniColours colour, string line)
    {
      return Writer.WriteLine(colour, line);
    }
  }
}
