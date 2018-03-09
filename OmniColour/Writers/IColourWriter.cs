using OmniColour.Messages;

namespace OmniColour.Writers
{
  public interface IColourWriter
  {
    IColourMessage Write(IColourMessage message);
  }
}
