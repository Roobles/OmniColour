using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;
using OmniColour.Environment.Interfaces;
using OmniColour.Messages;
using OmniColour.Providers.Interfaces;
using OmniColour.Writers.Output.Interfaces;

using SysEnv = System.Environment;

namespace OmniColour.Writers
{
  public class ColourWriter : IColourWriter
  {
    private readonly IOutputWriterProvider _provider;
    private readonly IEnvironmentParser _parser;
    private IOutputWriter _writer;

    private IOutputWriterProvider Provider { get { return _provider; } }

    private IEnvironmentParser Parser { get { return _parser; } }

    protected IOmniDecoration CurrentDecoration { get; private set; }

    private IOutputWriter Writer
    {
      get { return _writer ?? (_writer = Provider.GetOutputWriter()); }
    }

    internal ColourWriter(IOutputWriterProvider provider, IEnvironmentParser parser)
    {
      _provider = provider;
      _parser = parser;

      CurrentDecoration = Parser.GetCurrentDecorationSettings();
    }

    public IColourWriter ClearDecoration()
    {
      Writer.SetDecoration(OmniDecoration.None);
      return this;
    }

    public IColourWriter SetDecoration(IOmniDecoration decoration)
    {
      CurrentDecoration = decoration;
      return this;
    }

    public IColourMessage Write(IColourMessage message)
    {
      foreach(var entry in message.Build())
        WriteEntry(Writer, entry);

      Writer.SetDecoration(CurrentDecoration);
      return message;
    }

    public IColourWriter Write(string value)
    {
      WriteEntry(Writer, new ColourEntry(value, CurrentDecoration));
      return this;
    }

    public IColourWriter WriteFormat(string format, params object[] arguments)
    {
      return Write(string.Format(format, arguments));
    }

    public IColourWriter WriteLine(string line)
    {
      return Write(string.Format("{0}{1}", line, SysEnv.NewLine));
    }

    private static void WriteEntry(IOutputWriter writer, IColourEntry entry)
    {
      if (entry == null)
        return;

      writer.SetDecoration(entry.Decorations);
      writer.Write(entry.Message);
    }
  }
}
