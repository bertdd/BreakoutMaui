using System.Numerics;

namespace MauiBreakout2;

class Plane : Image
{
  internal void Move(AbsoluteLayout gameArea, int step)
  {
    var rect = gameArea.GetLayoutBounds(this);
    var x = rect.X + step;
    if (x < -rect.Width)
    {
      x = gameArea.Width;
    }
    var y = rect.Y;
    gameArea.SetLayoutBounds(this, new Rect(x, y, rect.Width, rect.Height));
  }
}
