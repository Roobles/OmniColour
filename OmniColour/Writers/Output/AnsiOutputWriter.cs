using System;
using System.IO;
using System.Text;
using OmniColour.Constants;
using OmniColour.Environment;
using OmniColour.Writers.Output.Interfaces;

namespace OmniColour.Writers.Output
{
  internal class AnsiOutputWriter : OutputWriter, IAnsiOutputWriter
  {
    public override CommandLineEnvironments TargetEnvironment
    {
      get { return CommandLineEnvironments.AnsiCompatible; }
    }

    protected override void SetColour(OmniColours color)
    {
      using (var stdout = Console.OpenStandardOutput())
        WriteColor(stdout, color);
    }

    protected void WriteColor(Stream source, OmniColours color)
    {
      WriteByteSequence(source, AnsiColours.InitControlSequence);
      WriteString(source, GetColorEncoding(color));
    }

    protected string GetColorEncoding(OmniColours color)
    {
      const string format = "1;{0}m";
      return string.Format(format, (int)color);
    }

    protected void WriteString(Stream source, string data)
    {
      WriteByteSequence(source, Encoding.ASCII.GetBytes(data));
    }

    protected void WriteByteSequence(Stream source, byte[] bytes)
    {
      using (var writer = new StreamWriter(source))
        writer.Write(bytes);
    }
  }
}
