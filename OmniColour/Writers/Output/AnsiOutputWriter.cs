using System;
using System.IO;
using System.Linq;
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
        using (var writer = new StreamWriter(stdout))
          WriteColour(writer, colour);
    }

    protected void WriteColour(StreamWriter writer, OmniColours colour)
    {
      WriteByteSequence(writer, AnsiColours.InitControlSequence);
      WriteString(writer, GetColourEncoding(colour));
    }

    protected string GetColourEncoding(OmniColours colour)
    {
      const string format = "1;{0}m";
      return string.Format(format, (int)colour);
    }

    protected void WriteString(StreamWriter writer, string data)
    {
      WriteByteSequence(writer, Encoding.ASCII.GetBytes(data));
    }

    protected void WriteByteSequence(StreamWriter writer, byte[] bytes)
    {
      writer.Write(bytes.Select(b => (char) b).ToArray());
    }
  }
}
