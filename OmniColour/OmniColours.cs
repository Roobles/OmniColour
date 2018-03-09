using System.ComponentModel;
using OmniColour.Constants;

namespace OmniColour
{
  public enum OmniColours
  {
    [Description(Win32Colours.Gray)]
    None = AnsiColours.None,

    [Description(Win32Colours.DarkRed)]
    Red = AnsiColours.Red,

    [Description(Win32Colours.DarkGreen)]
    Green = AnsiColours.Green,

    [Description(Win32Colours.DarkYellow)]
    Yellow = AnsiColours.Yellow,

    [Description(Win32Colours.DarkBlue)]
    Blue = AnsiColours.Blue,
    
    [Description(Win32Colours.DarkMagenta)]
    Magenta = AnsiColours.Magenta,
    
    [Description(Win32Colours.DarkCyan)]
    Cyan = AnsiColours.Cyan,

    [Description(Win32Colours.White)]
    White = AnsiColours.White,

    [Description(Win32Colours.Red)]
    BrightRed = AnsiColours.BrightRed,

    [Description(Win32Colours.Green)]
    BrightGreen = AnsiColours.BrightGreen,
    
    [Description(Win32Colours.Yellow)]
    BrightYellow = AnsiColours.BrightYellow,

    [Description(Win32Colours.Blue)]
    BrightBlue = AnsiColours.BrightBlue,
    
    [Description(Win32Colours.Magenta)]
    BrightMagenta = AnsiColours.BrightMagenta,
    
    [Description(Win32Colours.Cyan)]
    BrightCyan = AnsiColours.BrightCyan,
    
    [Description(Win32Colours.White)]
    BrightWhite = AnsiColours.BrightWhite
  }
}
