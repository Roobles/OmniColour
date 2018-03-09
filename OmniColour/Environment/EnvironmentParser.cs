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
  }
}
