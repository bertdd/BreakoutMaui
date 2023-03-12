namespace MauiBreakout2;

internal class Sun : Image
{
  public Sun()
  {
    Source = "sun.png";
    HorizontalOptions = LayoutOptions.Center;
  }

  internal void Turn()
  {
    Rotation += 0.1;
  }
}
