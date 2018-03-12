using System;
using OmniColour.Environment;
using OmniColour.Environment.Interfaces;
using OmniColour.Factories.Interfaces;
using OmniColour.Messages;
using OmniColour.Providers;
using OmniColour.Providers.Interfaces;
using OmniColour.Writers;
using OmniColour.Writers.Output;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Factories
{
  internal class OmniColourFactory : IOmniColourFactory, IOmniColourFactoryIoc
  {
    private static IColourWriter _writer;

    #region IOmniColourFactory Implementation
    public OmniColourFactory()
    {
      ColourWriterConstructor = BuildColourWriter;
      ColourMessageConstructor = BuildColourMessage;
      OutputWriterProviderContrustor = BuildOutputWriterProvider;
      EnvironmentParserConstructor = BuildEnvironmentParser;
      AnsiOutputWriterConstructor = BuildAnsiOutputWriter;
      Win32OutputWriterConstructor = BuildWin32OutputWriter;
      NullOutputWriterConstructor = BuildNullOutputWriter;
    }

    public IColourWriter BuildWriter()
    {
      return _writer ?? (_writer = ColourWriterConstructor());
    }

    public IColourMessage BuildMessage()
    {
      return ColourMessageConstructor();
    }

    public Func<IColourWriter> ColourWriterConstructor { get; set; }

    public Func<IColourMessage> ColourMessageConstructor { get; set; }

    public Func<IOutputWriterProvider> OutputWriterProviderContrustor { get; set; }
    
    public Func<IEnvironmentParser> EnvironmentParserConstructor { get; set; }

    public Func<IAnsiOutputWriter> AnsiOutputWriterConstructor { get; set; }
    
    public Func<IWin32OutputWriter> Win32OutputWriterConstructor { get; set; }
    
    public Func<INullOutputWriter> NullOutputWriterConstructor { get; set; }
    #endregion

    #region Constructors
    protected IColourWriter BuildColourWriter()
    {
      return new ColourWriter(OutputWriterProviderContrustor());  
    }

    protected IColourMessage BuildColourMessage()
    {
      return new ColourMessage();
    }

    protected IOutputWriterProvider BuildOutputWriterProvider()
    {
      var environmentParser = EnvironmentParserConstructor();
      var win32Writer = Win32OutputWriterConstructor();
      var ansiWriter = AnsiOutputWriterConstructor();
      var nullWriter = NullOutputWriterConstructor();

      return new StandardOutputWriterProvider(environmentParser, win32Writer, ansiWriter, nullWriter);
    }

    protected IEnvironmentParser BuildEnvironmentParser()
    {
      return new EnvironmentParser();
    }

    protected IAnsiOutputWriter BuildAnsiOutputWriter()
    {
      return new AnsiOutputWriter();
    }

    protected IWin32OutputWriter BuildWin32OutputWriter()
    {
      return new Win32OutputWriter();
    }

    protected INullOutputWriter BuildNullOutputWriter()
    {
      return new NullOutputWriter();
    }
    #endregion
  }
}
