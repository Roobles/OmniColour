using System;
using System.ComponentModel;
using System.Linq;
using OmniColour.Constants;
using OmniColour.Environment;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Writers.Output
{
  internal class Win32OutputWriter : OutputWriter, IWin32OutputWriter
  {
    public override CommandLineEnvironments TargetEnvironment
    {
      get { return CommandLineEnvironments.Win32; }
    }

    protected override void SetColour(OmniColours colour)
    {
      Console.ForegroundColor = ToConsoleColour(colour);
    }

    protected ConsoleColor ToConsoleColour(OmniColours colour)
    {
      // TODO: Improve this.
      return (ConsoleColor) Enum.Parse(typeof (ConsoleColor), GetConsoleColourName(colour));
    }

    private static string GetConsoleColourName(OmniColours colour)
    {
      string parsed;
      return string.IsNullOrEmpty(parsed = GetDescription(colour))
        ? Win32Colours.DefaultColour
        : parsed;
    }

    private static string GetDescription(OmniColours colour)
    {
      var enumType = colour.GetType();
      var enumInfo = enumType.GetField(colour.ToString());
      var descriptionAttribute = enumInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)
        .OfType<DescriptionAttribute>()
        .FirstOrDefault();

      return descriptionAttribute != null
        ? descriptionAttribute.Description
        : string.Empty;
    }
  }
}
