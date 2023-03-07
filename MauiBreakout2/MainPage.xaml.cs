namespace MauiBreakout2
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();

      var timer = Dispatcher.CreateTimer();
      timer.Interval = TimeSpan.FromMilliseconds(25);
      timer.IsRepeating = true;
      timer.Tick += Timer_Tick!;
      timer.Start();

      gameArea.SizeChanged += Layout_SizeChanged!;
    }

    private void Layout_SizeChanged(object sender, EventArgs e)
    {
      var rect = gameArea.GetLayoutBounds(boris);
      gameArea.SetLayoutBounds(boris, new Rect((Width - rect.Width) / 2,
        Height - rect.Height - 10, rect.Width, rect.Height));
      gameArea.SetLayoutBounds(background, new Rect(0, 0, Width, Height));
      gameArea.SetLayoutBounds(rainbow, new Rect(Width - 400, Height - 450, 350, 350));
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
#if test
      if (pad != null)
      {
        var reading = pad.GetCurrentReading();
        var deltaX = reading.LeftThumbstickX;

        var botRect = gameArea.GetLayoutBounds(bot);
        var x = (Width - botRect.Width) / 2 + deltaX * Width / 2;
        x = Math.Min(Math.Max(x, 0), Width - botRect.Width);
        gameArea.SetLayoutBounds(bot, new Rect(x,
          Height - botRect.Height - 10, botRect.Width, botRect.Height));
      }
#endif

      bird.Move(gameArea, boris);
      cloud.Move(gameArea, 1);
      cloud2.Move(gameArea, 2);
      cloud3.Move(gameArea, 4);
      plane.Move(gameArea, -2);
      Rainbow();
    }

    private void Rainbow()
    {
      if (rainbow.Opacity < 1)
      {
        rainbow.Opacity += 0.001;
      }
    }
  }
}