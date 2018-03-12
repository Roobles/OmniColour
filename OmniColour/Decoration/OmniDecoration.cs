using OmniColour.Decoration.Interfaces;

namespace OmniColour.Decoration
{
  internal class OmniDecoration : IOmniDecoration
  {
    #region Static
    private static readonly OmniDecoration VoidDecoration;

    public static IOmniDecoration None { get { return VoidDecoration; } }

    static OmniDecoration()
    {
      VoidDecoration = new OmniDecoration(OmniColours.None);
    }
    #endregion

    private readonly OmniColours _colour;

    public OmniColours Colour { get { return _colour; } }

    public OmniDecoration(OmniColours color)
    {
      _colour = color;
    }
  }
}
