namespace MauiBreakout2;

internal abstract class GameObject : Image
{
    private int step = 3;

    internal void MoveHorizontal(AbsoluteLayout gameArea, double step, bool beak = false)
    {
        var rectangle = gameArea.GetLayoutBounds(this);
        var x = rectangle.X + step;
        if (x > gameArea.Width)
        {
            x = -Width;
        }
        else
        {
            if (beak)
            {
                if (x < -rectangle.Width - 100)
                {
                    x = gameArea.Width;
                }
            }
            else
            {
                if (x < -rectangle.Width)
                {
                    x = gameArea.Width;
                }
            }


        }
        var y = rectangle.Y;
        gameArea.SetLayoutBounds(this, new Rect(x, y, rectangle.Width, rectangle.Height));
    }

    internal void MoveVertical(AbsoluteLayout gameArea)
    {

        var rectangle = gameArea.GetLayoutBounds(this);
        var x = rectangle.X;

        var y = rectangle.Y + step;

        if (y > gameArea.Height - 145)
        {
            step = -3;
        }
        else if (y < gameArea.Height - 155)
        {
            step = 3;
        }
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
