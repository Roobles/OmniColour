using System.Collections.Generic;
using System.Collections.ObjectModel;
using OmniColour.Decoration.Interfaces;

namespace OmniColour.Messages
{
  internal class ColourMessage : IColourMessage
  {
    private readonly List<IColourEntry> _entries;

    protected IList<IColourEntry> Entries { get { return _entries; } } 

    public ColourMessage()
    {
      _entries = new List<IColourEntry>();
    }

    public IColourMessage Append(string value)
    {
      return AppendEntry(value);
    }

    public IColourMessage Append(IOmniDecoration decoration, string value)
    {
      return AppendEntry(value, decoration);
    }

    public IColourMessage AppendLine(string value)
    {
      return AppendLine(null, value);
    }

    public IColourMessage AppendLine(IOmniDecoration decoration, string value)
    {
      var line = string.Format("{0}{1}", value, System.Environment.NewLine);
      return AppendEntry(line, decoration);
    }

    public IColourMessage AppendFormat(string format, params object[] arguments)
    {
      return AppendFormat(null, format, arguments);
    }

    public IColourMessage AppendFormat(IOmniDecoration decoration, string format, params object[] arguments)
    {
      var value = string.Format(format, arguments);
      return AppendEntry(value, decoration);
    }

    public Collection<IColourEntry> Build()
    {
      return new Collection<IColourEntry>(Entries);
    }

    public IColourMessage Clear()
    {
      Entries.Clear();
      return this;
    }

    protected IColourMessage AppendEntry(string value, IOmniDecoration decoration = null)
    {
      Entries.Add(new ColourEntry(value, decoration));
      return this;
    }
  }
}
