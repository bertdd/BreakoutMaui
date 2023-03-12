namespace MauiBreakout2;

internal abstract class GameObject : Image
{
  internal void MoveHorizontal(AbsoluteLayout gameArea, double step)
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

  internal void AnchorBottom(AbsoluteLayout area, double height)
  {
    var rect = area.GetLayoutBounds(this);
    if (rect.Height > 0 && rect.Width > 0)
    {
      area.SetLayoutBounds(this, new Rect(rect.X,
      height - rect.Height - 10, rect.Width, rect.Height));
    }
  }

}
