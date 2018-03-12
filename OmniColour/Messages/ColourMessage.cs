using System.Collections.Generic;
using System.Collections.ObjectModel;
using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;

namespace OmniColour.Messages
{
  internal class ColourMessage : IColourMessage
  {
    private readonly List<IColourEntry> _entries;

    protected IList<IColourEntry> Entries { get { return _entries; } }

    private IOmniDecoration Decoration { get; set; }

    public ColourMessage()
    {
      _entries = new List<IColourEntry>();
      Decoration = OmniDecoration.None;
    }

    public IColourMessage Append(string value)
    {
      return AppendEntry(value, GetDecoration());
    }

    public IColourMessage Append(IOmniDecoration decoration, string value)
    {
      return AppendEntry(value, decoration);
    }

    public IColourMessage Append(OmniColours colour, string value)
    {
      return Append(ToDecoration(colour), value);
    }

    public IColourMessage AppendLine(string value)
    {
      return AppendLine(GetDecoration(), value);
    }

    public IColourMessage AppendLine(IOmniDecoration decoration, string value)
    {
      var line = string.Format("{0}{1}", value, System.Environment.NewLine);
      return AppendEntry(line, decoration);
    }

    public IColourMessage AppendLine(OmniColours colour, string value)
    {
      return AppendLine(ToDecoration(colour), value);
    }

    public IColourMessage AppendFormat(string format, params object[] arguments)
    {
      return AppendFormat(GetDecoration(), format, arguments);
    }

    public IColourMessage AppendFormat(IOmniDecoration decoration, string format, params object[] arguments)
    {
      var value = string.Format(format, arguments);
      return AppendEntry(value, decoration);
    }

    public IColourMessage AppendFormat(OmniColours colour, string format, params object[] arguments)
    {
      return AppendFormat(ToDecoration(colour), format, arguments);
    }

    public Collection<IColourEntry> Build()
    {
      return new Collection<IColourEntry>(Entries);
    }

    public IColourMessage Clear()
    {
      SetDecoration(OmniDecoration.None);
      Entries.Clear();
      return this;
    }

    public IOmniDecoration GetDecoration()
    {
      return Decoration;
    }

    public IColourMessage SetDecoration(IOmniDecoration decoration)
    {
      Decoration = decoration ?? OmniDecoration.None;
      return this;
    }

    protected IColourMessage AppendEntry(string value, IOmniDecoration decoration = null)
    {
      Entries.Add(new ColourEntry(value, decoration));
      return this;
    }

    protected IOmniDecoration ToDecoration(OmniColours colour)
    {
      return new OmniDecoration(colour);
    }
  }
}
