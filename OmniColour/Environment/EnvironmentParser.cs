using OmniColour.Decoration;
using OmniColour.Decoration.Interfaces;
using OmniColour.Environment.Interfaces;

using SysEnv = System.Environment;

namespace OmniColour.Environment
{
  internal class EnvironmentParser : IEnvironmentParser
  {
    public CommandLineEnvironments GetEnvironment()
    {
      const string term = "TERM";
      
      return string.IsNullOrEmpty(SysEnv.GetEnvironmentVariable(term))
        ? CommandLineEnvironments.Win32
        : CommandLineEnvironments.AnsiCompatible;
    }

    public IOmniDecoration GetCurrentDecorationSettings()
    {
      CommandLineEnvironments env;
      return (env = GetEnvironment()) == CommandLineEnvironments.AnsiCompatible
        ? GetAnsiCurrentDecoration()
        : env == CommandLineEnvironments.Win32
          ? GetWin32CurrentDecoration()
          : OmniDecoration.None;
    }

    protected IOmniDecoration GetWin32CurrentDecoration()
    {
      // TODO: Implement this.
      return OmniDecoration.None;
    }

    protected IOmniDecoration GetAnsiCurrentDecoration()
    {
      // TODO: Implement this.
      return OmniDecoration.None;
    }
  }
}
