using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;
using OmniColour.Factories;
using OmniColour.Messages;
using OmniColour.Writers;

namespace OmniColour
{
  public static class Colour
  {
    private static readonly IColourWriter ColourWriter;

    public static IColourWriter Writer { get { return ColourWriter; } }

    public static IColourMessage Message { get { return OmniColourFactory.Factory.BuildMessage(); } }

    static Colour()
    {
      ColourWriter = OmniColourFactory.Factory.BuildWriter();
    }

    public static IOmniDecoration Decoration(OmniColours colour)
    {
      return new OmniDecoration(colour);
    }

    public static IColourWriter ClearDecoration()
    {
      return Writer.ClearDecoration();  
    }

    public static IColourWriter SetDecoration(IOmniDecoration decoration)
    {
      return Writer.SetDecoration(decoration);
    }

    public static IColourMessage Write(IColourMessage message)
    {
      return Writer.Write(message);
    }

    public static IColourWriter Write(string value)
    {
      return Writer.WriteFormat(value);
    }

    public static IColourWriter WriteFormat(string format, params object[] arguments)
    {
      return Writer.WriteFormat(format, arguments);
    }

    public static IColourWriter WriteLine(string line)
    {
      return Writer.WriteLine(line);
    }
  }
}
