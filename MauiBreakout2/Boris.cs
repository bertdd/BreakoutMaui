namespace MauiBreakout2;

internal class Boris : GameObject
{
  public Boris()
  {
    Source = "boris.png";
    HorizontalOptions = LayoutOptions.Center;
  }

  internal void Move(AbsoluteLayout gameArea, double? deltaX)
  {
    if (deltaX != null)
    {
      var rect = gameArea.GetLayoutBounds(this);
      var x = (double)((gameArea.Width - rect.Width) / 2 + deltaX * gameArea.Width / 2);
      x = Math.Min(Math.Max(x, 0), gameArea.Width - rect.Width);
      gameArea.SetLayoutBounds(this, new Rect(x, rect.Y, rect.Width, rect.Height));
    }
  }
}
