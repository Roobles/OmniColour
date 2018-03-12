using OmniColour.Decoration.Interfaces;

namespace OmniColour.Environment.Interfaces
{
  internal interface IEnvironmentParser
  {
    CommandLineEnvironments GetEnvironment();

    IOmniDecoration GetCurrentDecorationSettings();
  }
}
