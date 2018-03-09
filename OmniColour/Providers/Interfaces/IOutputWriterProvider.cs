using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Providers.Interfaces
{
  internal interface IOutputWriterProvider
  {
    IOutputWriter GetOutputWriter();
  }
}
