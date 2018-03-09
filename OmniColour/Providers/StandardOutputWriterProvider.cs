using OmniColour.Environment;
using OmniColour.Environment.Interfaces;
using OmniColour.Providers.Interfaces;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Providers
{
  internal class StandardOutputWriterProvider : IOutputWriterProvider
  {
    private readonly IEnvironmentParser _environmentParser;
    private readonly IWin32OutputWriter _win32Writer;
    private readonly IAnsiOutputWriter _ansiWriter;
    private readonly INullOutputWriter _nullWriter;

    protected IEnvironmentParser EnvironmentParser {get { return _environmentParser; }}

    protected IWin32OutputWriter Win32Writer { get { return _win32Writer; } }

    protected IAnsiOutputWriter AnsiWriter { get { return _ansiWriter; } }

    protected INullOutputWriter NullWriter { get { return _nullWriter; } }

    public StandardOutputWriterProvider(IEnvironmentParser environmentParser, IWin32OutputWriter win32Writer, IAnsiOutputWriter ansiWriter, INullOutputWriter nullWriter)
    {
      _environmentParser = environmentParser;
      _win32Writer = win32Writer;
      _ansiWriter = ansiWriter;
      _nullWriter = nullWriter;
    }

    public IOutputWriter GetOutputWriter()
    {
      return GetOutputWriter(EnvironmentParser.GetEnvironment());
    }

    protected IOutputWriter GetOutputWriter(CommandLineEnvironments env)
    {
      switch (env)
      {
        case CommandLineEnvironments.AnsiCompatible:
          return AnsiWriter;

        case CommandLineEnvironments.Win32:
          return Win32Writer;

        default:
          return NullWriter;
      }
    }
  }
}
