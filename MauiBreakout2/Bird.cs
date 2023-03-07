﻿namespace MauiBreakout2;

public class Bird : Image
{
  public Bird()
  {
    Rotate = RotationY = 180;
    Rotation = 0;
  }

  internal void Move(AbsoluteLayout gameArea, Boris boris)
  {
    var rect = gameArea.GetLayoutBounds(this);
    var x = rect.X + XDir * 10;
    var y = rect.Y + YDir * 10;

    if (y + rect.Height > gameArea.Height || y < 0)
    {
      YDir = -YDir;
      Round = Round == 0 ? 90 : 0;
      this.RotateTo(Round);
    }

    if (x + rect.Width > gameArea.Width || x < 0)
    {
      XDir = -XDir;
      Rotate = Rotate == 0 ? 180 : 0;
      this.RotateYTo(Rotate);
    }

    x = Math.Max(0, x);
    y = Math.Max(0, y);
    x = Math.Min(gameArea.Width - rect.Width, x);
    y = Math.Min(gameArea.Height - rect.Height, y);

    gameArea.SetLayoutBounds(this, new Rect(x, y, rect.Width, rect.Height));
    if (MoveStep == Tumble)
    {
      this.RotateTo(360);
      MoveStep = 0;
      Tumble = random.Next(20);
      XDir = -XDir;
    }
    var botRect = gameArea.GetLayoutBounds(boris);
    if (botRect.IntersectsWith(rect))
    {
      if (Wait == 0)
      {
        XDir = -XDir;
        YDir = -YDir;
        Wait = 10;
      }
      else
      {
        Wait--;
      }
    }
    Tumble = random.Next(20);
  }

  private int XDir = 1;

  private int YDir = 1;

  private double Round = 0;

  private double Rotate = 0;

  private int Tumble = 0;

  private int MoveStep = 0;

  private int Wait = 0;

  private readonly Random random = new();
}
