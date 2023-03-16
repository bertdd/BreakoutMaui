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

  internal void AnchorBottom(AbsoluteLayout area, double height, double distance = 10)
  {
    var rectangle = area.GetLayoutBounds(this);
    if (rectangle.Height > 0 && rectangle.Width > 0)
    {
      var newRectangle = 
        new Rect(rectangle.X, height - rectangle.Height - distance, 
                 rectangle.Width, rectangle.Height);

      area.SetLayoutBounds(this, newRectangle);
    }
  }

}
