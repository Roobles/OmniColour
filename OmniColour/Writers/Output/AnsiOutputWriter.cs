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

    protected override void SetColour(OmniColours colour)
    {
      using (var stdout = Console.OpenStandardOutput())
        WriteColour(stdout, colour);
    }

    protected void WriteColour(Stream source, OmniColours colour)
    {
      WriteByteSequence(source, AnsiColours.InitControlSequence);
      WriteString(source, GetColourEncoding(colour));
    }

    protected string GetColourEncoding(OmniColours colour)
    {
      const string format = "1;{0}m";
      return string.Format(format, (int)colour);
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
