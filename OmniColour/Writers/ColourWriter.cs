using OmniColour.Messages;
using OmniColour.Providers.Interfaces;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Writers
{
  public class ColourWriter : IColourWriter
  {
    private readonly IOutputWriterProvider _provider;
    private IOutputWriter _writer;

    private IOutputWriterProvider Provider { get { return _provider; } }

    private IOutputWriter Writer
    {
      get { return _writer ?? (_writer = Provider.GetOutputWriter()); }
    }

    internal ColourWriter(IOutputWriterProvider provider)
    {
      _provider = provider;
    }

    public IColourMessage Write(IColourMessage message)
    {
      foreach(var entry in message.Build())
        WriteEntry(Writer, entry);

      return message;
    }

    private void WriteEntry(IOutputWriter writer, IColourEntry entry)
    {
      if (entry == null)
        return;

      writer.SetDecoration(entry.Decorations);
      writer.Write(entry.Message);
    }
  }
}
