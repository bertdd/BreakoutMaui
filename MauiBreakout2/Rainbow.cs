namespace MauiBreakout2;

class Rainbow : GameObject
{
  public Rainbow()
  {
    Source = "Rainbow.png";
    HorizontalOptions = LayoutOptions.Center;
    Opacity = 0;
  }

  internal void Tick()
  {
    if (Opacity < 1)
    {
      Opacity += 0.001;
    }
  }
}
