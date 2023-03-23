namespace MauiBreakout2;

class backgroundchange { }
internal class Background : Image
{
    public Background()
    {
        Source = "background.jpg";
        Aspect = Aspect.AspectFill;
        Opacity = 1;
    }
    internal void Tick()
    {
        if (Opacity > 0)
        {
            Opacity -= 0.001;
        }
    }
}

internal class Backgroundnight : Image
{
    public Backgroundnight()
    {
        Source = "background2.jpg";
        Aspect = Aspect.AspectFill;
        Opacity = 0;
    }
    internal void Tick()
    {
        if (Opacity < 1)
        {
            Opacity += 0.001;
        }
    }
}
