namespace OmniColour.Constants
{
  /// <summary>
  /// ANSI colour code values.
  /// </summary>
  public static class AnsiColours
  {
    public const int None = 0x0;
    public const int Red = 0x1F;
    public const int Green = 0x20;
    public const int Yellow = 0x21;
    public const int Blue = 0x22;
    public const int Magenta = 0x23;
    public const int Cyan = 0x24;
    public const int White = 0x25;
    public const int BrightRed = 0x5B;
    public const int BrightGreen = 0x5C;
    public const int BrightYellow = 0x5D;
    public const int BrightBlue = 0x5E;
    public const int BrightMagenta = 0x5F;
    public const int BrightCyan = 0x60;
    public const int BrightWhite = 0x61;

    public const byte EscBytes = 0x1B;
    public const byte ControlSequenceBytes = 0x9B;

    public static readonly byte[] InitControlSequence =
    {
      EscBytes,
      ControlSequenceBytes
    };
}
}
