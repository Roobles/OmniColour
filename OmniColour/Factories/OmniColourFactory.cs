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
    private static OmniColourFactory _factory;
    
    private static Func<IColourWriter> _colourWriterConstructor;
    private static Func<IColourMessage> _colourMessageConstructor;
    private static Func<IOutputWriterProvider> _outputWriterProviderContrustor;
    private static Func<IEnvironmentParser> _environmentParserConstructor;
    private static Func<IAnsiOutputWriter> _ansiOutputWriterConstructor;
    private static Func<IWin32OutputWriter> _win32OutputWriterConstructor;
    private static Func<INullOutputWriter> _nullOutputWriterConstructor;

    #region IOmniColourFactory Implementation
    private OmniColourFactory()
    {
      SetStandard();
    }

    private static OmniColourFactory IocFactory { get { return _factory ?? (_factory = new OmniColourFactory()); } }

    public static IOmniColourFactory Factory { get { return IocFactory; } }

    public static IOmniColourFactoryIoc IoC { get { return IocFactory; } }

    public void SetStandard()
    {
      _colourWriterConstructor = BuildColourWriter;
      _colourMessageConstructor = BuildColourMessage;
      _outputWriterProviderContrustor = BuildOutputWriterProvider;
      _environmentParserConstructor = BuildEnvironmentParser;
      _ansiOutputWriterConstructor = BuildAnsiOutputWriter;
      _win32OutputWriterConstructor = BuildWin32OutputWriter;
      _nullOutputWriterConstructor = BuildNullOutputWriter;

      Rebuild();
    }

    public IColourWriter BuildWriter()
    {
      return _writer ?? (_writer = ColourWriterConstructor());
    }

    public IColourMessage BuildMessage()
    {
      return ColourMessageConstructor();
    }

    public Func<IColourWriter> ColourWriterConstructor
    {
      get { return _colourWriterConstructor; }
      set { _colourWriterConstructor = value; Rebuild(); }
    }

    public Func<IColourMessage> ColourMessageConstructor
    {
      get { return _colourMessageConstructor; }
      set { _colourMessageConstructor = value; Rebuild(); }
    }

    public Func<IOutputWriterProvider> OutputWriterProviderContrustor
    {
      get { return _outputWriterProviderContrustor; }
      set { _outputWriterProviderContrustor = value; Rebuild(); }
    }

    public Func<IEnvironmentParser> EnvironmentParserConstructor
    {
      get { return _environmentParserConstructor; }
      set { _environmentParserConstructor = value; Rebuild(); }
    }

    public Func<IAnsiOutputWriter> AnsiOutputWriterConstructor
    {
      get { return _ansiOutputWriterConstructor; }
      set { _ansiOutputWriterConstructor = value; Rebuild(); }
    }

    public Func<IWin32OutputWriter> Win32OutputWriterConstructor
    {
      get { return _win32OutputWriterConstructor; }
      set { _win32OutputWriterConstructor = value; Rebuild(); }
    }

    public Func<INullOutputWriter> NullOutputWriterConstructor
    {
      get { return _nullOutputWriterConstructor; }
      set { _nullOutputWriterConstructor = value; Rebuild(); }
    }
    #endregion

    #region Constructors
    protected IColourWriter BuildColourWriter()
    {
      var provider = OutputWriterProviderContrustor();
      var parser = EnvironmentParserConstructor();
      return new ColourWriter(provider, parser, this);
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

    protected static IEnvironmentParser BuildEnvironmentParser()
    {
      return new EnvironmentParser();
    }

    protected static IAnsiOutputWriter BuildAnsiOutputWriter()
    {
      return new AnsiOutputWriter();
    }

    protected static IWin32OutputWriter BuildWin32OutputWriter()
    {
      return new Win32OutputWriter();
    }

    protected static INullOutputWriter BuildNullOutputWriter()
    {
      return new NullOutputWriter();
    }
    #endregion

    #region Helper Methods

    private void Rebuild()
    {
      _writer = ColourWriterConstructor();
    }
    #endregion
  }
}
