using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;
using OmniColour.Environment.Interfaces;
using OmniColour.Factories.Interfaces;
using OmniColour.Messages;
using OmniColour.Providers.Interfaces;
using OmniColour.Writers.Output.Interfaces;

using SysEnv = System.Environment;

namespace OmniColour.Writers
{
  internal class ColourWriter : IColourWriter
  {
    private readonly IOmniColourFactory _factory;
    private readonly IOutputWriterProvider _provider;
    private readonly IEnvironmentParser _parser;
    private IOutputWriter _writer;

    private IOutputWriterProvider Provider { get { return _provider; } }

    private IEnvironmentParser Parser { get { return _parser; } }

    protected IOmniDecoration CurrentDecoration { get; private set; }

    protected IOmniColourFactory Factory { get { return _factory; } }

    private IOutputWriter Writer
    {
      get { return _writer ?? (_writer = Provider.GetOutputWriter()); }
    }

    internal ColourWriter(IOutputWriterProvider provider, IEnvironmentParser parser, IOmniColourFactory factory)
    {
      _provider = provider;
      _parser = parser;
      _factory = factory;

      CurrentDecoration = Parser.GetCurrentDecorationSettings();
    }

    public IColourMessage Message
    {
      get { return Factory.BuildMessage(); }
    }

    public IColourWriter ClearDecoration()
    {
      var none = OmniDecoration.None;
      SetDecoration(none);
      Writer.SetDecoration(none);
      return this;
    }

    public IOmniDecoration GetDecoration()
    {
      return CurrentDecoration;
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

    public IColourWriter Write(OmniColours colour, string value)
    {
      Write(ToMessage(colour, value));
      return this;
    }

    public IColourWriter WriteFormat(string format, params object[] arguments)
    {
      return Write(string.Format(format, arguments));
    }

    public IColourWriter WriteFormat(OmniColours colour, string format, params object[] arguments)
    {
      return Write(colour, string.Format(format, arguments));
    }

    public IColourWriter WriteLine(string line)
    {
      return Write(string.Format("{0}{1}", line, SysEnv.NewLine));
    }

    public IColourWriter WriteLine(OmniColours colour, string line)
    {
      return Write(colour, string.Format("{0}{1}", line, SysEnv.NewLine));
    }

    private static void WriteEntry(IOutputWriter writer, IColourEntry entry)
    {
      if (entry == null)
        return;

      writer.SetDecoration(entry.Decorations);
      writer.Write(entry.Message);
    }

    public static IOmniDecoration ToDecoration(OmniColours colour)
    {
      return new OmniDecoration(colour);
    }
    
    private static IColourMessage ToMessage(OmniColours colour, string value)
    {
      return new ColourMessage().Append(ToDecoration(colour), value);
    }
  }
}
