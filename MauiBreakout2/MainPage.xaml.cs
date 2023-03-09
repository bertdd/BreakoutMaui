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
      if (Control.UseGameController())
      {
        boris.Move(gameArea, Control.GetX());
      }

      bird.Move(gameArea, boris);
      cloud.Move(gameArea, 1);
      cloud2.Move(gameArea, 2);
      cloud3.Move(gameArea, 4);
      plane.Move(gameArea, -2);
      plane2.Move(gameArea, 10);
      rainbow.Tick();
      sun.Turn();
    }

    readonly private PlayerControl Control = new();
  }
}