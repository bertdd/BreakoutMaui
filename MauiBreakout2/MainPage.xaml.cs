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

      viewArea.SizeChanged += Layout_SizeChanged!;
    }

    private void OnTapped(object sender, TappedEventArgs e)
    {
      var point = e.GetPosition(this);
      if (point != null)
      {
        var borisX = (point?.X / gameArea.Width * 2) - 1.0;
        boris.Move(gameArea, borisX);
      }
    }
    
    private void Layout_SizeChanged(object sender, EventArgs e)
    {
      boris.AnchorBottom(gameArea, Height);
      croco.AnchorBottom(gameArea, Height);
      cactus.AnchorBottom(gameArea, Height, 100);
      rainbow.AnchorBottom(gameArea, Height);
      gameArea.SetLayoutBounds(background, new Rect(0, 0, Width, Height));
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (Control.UseGameController())
      {
        boris.Move(gameArea, Control.GetX());
      }

      bird.Move(gameArea, boris);
      cloud.MoveHorizontal(gameArea, 1);
      cloud2.MoveHorizontal(gameArea, 2);
      cloud3.MoveHorizontal(gameArea, 4);
      cloud4.MoveHorizontal(gameArea, 8);
      plane.MoveHorizontal(gameArea, -2);
      plane2.MoveHorizontal(gameArea, 10);
      croco.MoveHorizontal(gameArea, -0.5);
      rainbow.Tick();
      sun.Turn();
    }

    readonly private PlayerControl Control = new();
  }
}