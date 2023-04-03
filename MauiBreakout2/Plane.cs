namespace MauiBreakout2;

class Plane : GameObject
{
  public Plane()
  {
    RotationY = 180;
    Source = "plane.png";
    HorizontalOptions = LayoutOptions.Center;
  }
}
