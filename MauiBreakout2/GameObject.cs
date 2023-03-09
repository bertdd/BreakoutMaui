namespace MauiBreakout2;

internal abstract class GameObject : Image
{
  internal void Move(AbsoluteLayout gameArea, int step)
  {
    var rectangle = gameArea.GetLayoutBounds(this);
    var x = rectangle.X + step;
    if (x > gameArea.Width)
    {
      x = -Width;
    }
    else
    {
      if (x < -rectangle.Width)
      {
        x = gameArea.Width;
      }
    }
    var y = rectangle.Y;
    gameArea.SetLayoutBounds(this, new Rect(x, y, rectangle.Width, rectangle.Height));
  }
}
