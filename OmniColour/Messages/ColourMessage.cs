using System;
using System.Collections.ObjectModel;
using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;

namespace OmniColour.Messages
{
  internal class ColourMessage : IColourMessage
  {
    public IColourMessage Append(string value)
    {
      throw new NotImplementedException();
    }

    public IColourMessage Append(IOmniDecoration decoration, string value)
    {
      throw new NotImplementedException();
    }

    public IColourMessage AppendLine(string value)
    {
      throw new NotImplementedException();
    }

    public IColourMessage AppendLine(IOmniDecoration decoration, string value)
    {
      throw new NotImplementedException();
    }

    public IColourMessage AppendFormat(string format, params object[] arguments)
    {
      throw new NotImplementedException();
    }

    public IColourMessage AppendFormat(IOmniDecoration decoration, string format, params object[] arguments)
    {
      throw new NotImplementedException();
    }

    public Collection<IColourEntry> Build()
    {
      throw new NotImplementedException();
    }

    public IColourMessage Clear()
    {
      throw new NotImplementedException();
    }
  }
}
