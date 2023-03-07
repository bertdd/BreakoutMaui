using System.Runtime.InteropServices;

namespace MauiBreakout2;

class Cloud : Image
{
  internal void Move(AbsoluteLayout gameArea, int step)
  {
    var rect = gameArea.GetLayoutBounds(this);
    var x = rect.X + step;
    if (x > gameArea.Width)
    {
      x = -Width;
    }
    var y = rect.Y;
    gameArea.SetLayoutBounds(this, new Rect(x, y, rect.Width, rect.Height));
  }
}
