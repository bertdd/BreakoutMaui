namespace MauiBreakout2;

internal class Sun : Image
{
    private bool isMovingUp = true;
    private double stepSize = 10; 

    public Sun()
    {
        Source = "sun.png";
        HorizontalOptions = LayoutOptions.Center;

        Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
        {
            if (isMovingUp)
            {
                TranslationY -= stepSize;
            }
            else
            {
                TranslationY += stepSize;
            }

            if (TranslationY <= -20)
            {
                isMovingUp = false;
            }
            else if (TranslationY >= 800)
            {
                isMovingUp = true;
            }

            return true;
        });
    }
}