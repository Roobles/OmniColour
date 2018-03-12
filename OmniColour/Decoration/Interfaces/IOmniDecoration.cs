namespace OmniColour.Decoration.Interfaces
{
  /// <summary>
  /// Decoration information on how text should be displayed on the command line.
  /// </summary>
  public interface IOmniDecoration
  {
    OmniColours Colour { get; }
  }
}
