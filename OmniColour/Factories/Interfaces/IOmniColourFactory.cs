using System;
using OmniColour.Environment.Interfaces;
using OmniColour.Messages;
using OmniColour.Providers.Interfaces;
using OmniColour.Writers;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Factories.Interfaces
{
  internal interface IOmniColourFactory
  {
    IColourWriter BuildWriter();

    IColourMessage BuildMessage();

    Func<IColourWriter> ColourWriterConstructor { get; set; }

    Func<IColourMessage> ColourMessageConstructor { get; set; }

    Func<IOutputWriterProvider> OutputWriterProviderContrustor { get; set; }

    Func<IEnvironmentParser> EnvironmentParserConstructor { get; set; }

    Func<IAnsiOutputWriter> AnsiOutputWriterConstructor { get; set; }

    Func<IWin32OutputWriter> Win32OutputWriterConstructor { get; set; }

    Func<INullOutputWriter> NullOutputWriterConstruct { get; set; } 
  }
}
