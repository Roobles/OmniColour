using OmniColour.Decoration.Interfaces;
using OmniColour.Messages;

namespace OmniColour.Writers
{
  public interface IColourWriter
  {
    IColourWriter ClearDecoration();

    IColourWriter SetDecoration(IOmniDecoration decoration);

    IColourMessage Write(IColourMessage message);

    IColourWriter Write(string value);

    IColourWriter WriteFormat(string format, params object[] arguments);

    IColourWriter WriteLine(string line);
  }
}
