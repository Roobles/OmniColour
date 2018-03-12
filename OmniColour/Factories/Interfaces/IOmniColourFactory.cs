using OmniColour.Messages;
using OmniColour.Writers;

namespace OmniColour.Factories.Interfaces
{
  internal interface IOmniColourFactory
  {
    IColourWriter BuildWriter();

    IColourMessage BuildMessage();
  }
}
