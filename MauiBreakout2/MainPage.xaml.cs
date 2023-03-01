using Microsoft.Maui.Controls.Shapes;
using Windows.Gaming.Input;

namespace MauiBreakout2
{
  public partial class MainPage : ContentPage
  {
    readonly IDispatcherTimer timer;

    public MainPage()
    {
      InitializeComponent();

      Gamepad.GamepadAdded += Gamepad_GamepadAdded;
      timer = Dispatcher.CreateTimer();
      timer.Interval = TimeSpan.FromMilliseconds(25);
      timer.IsRepeating = true;
      timer.Tick += Timer_Tick;
      timer.Start();

      gameArea.SizeChanged += Layout_SizeChanged;
      Rotate = dolphin.RotationY = 180;
      dolphin.Rotation = 0;
      plane.RotationY = 180;
    }

    private void Layout_SizeChanged(object sender, EventArgs e)
    {
      var botRect = gameArea.GetLayoutBounds(bot);
      gameArea.SetLayoutBounds(bot, new Rect((Width - botRect.Width) / 2,
        Height - botRect.Height - 10, botRect.Width, botRect.Height));
      gameArea.SetLayoutBounds(background, new Rect(0, 0, Width, Height));
      gameArea.SetLayoutBounds(rainbow, new Rect(Width - 400, Height - 450, 350, 350));
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
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

      MoveDolphin();
      MoveCloud();
      MoveCloud2();
      MovePlane();
      Rainbow();
      Tumble = random.Next(20);
    }

    private void MoveCloud()
    {
      var rect = gameArea.GetLayoutBounds(cloud);
      var x = rect.X + 1;
      if (x > Width)
      {
        x = -cloud.Width;
      }
      var y = rect.Y;
      gameArea.SetLayoutBounds(cloud, new Rect(x, y, rect.Width, rect.Height));
    }

    private void MoveCloud2()
    {
      var rect = gameArea.GetLayoutBounds(cloud2);
      var x = rect.X + 2;
      if (x > Width)
      {
        x = -cloud2.Width;
      }
      var y = rect.Y;
      gameArea.SetLayoutBounds(cloud2, new Rect(x, y, rect.Width, rect.Height));
    }

    private void MovePlane()
    {
      var rect = gameArea.GetLayoutBounds(plane);
      var x = rect.X - 2;
      if (x < -rect.Width)
      {
        x = Width;
      }
      var y = rect.Y;
      gameArea.SetLayoutBounds(plane, new Rect(x, y, rect.Width, rect.Height));
    }

    private void Rainbow()
    {
      if (rainbow.Opacity < 1)
      {
        rainbow.Opacity += 0.001;
      }
    }



    private int XDir = 1;
    private int YDir = 1;
    private double Rotate = 0;
    private double Round = 0;
    private int Tumble = 0;
    private int Move = 0;
    private int Wait = 0;

    Random random = new Random();
    private void MoveDolphin()
    {
      var dolphinRect = gameArea.GetLayoutBounds(dolphin);
      var x = dolphinRect.X + XDir * 10;
      var y = dolphinRect.Y + YDir * 10;
      if (y + dolphinRect.Height > Height || y < 0)
      {
        YDir = -YDir;
        Round = Round == 0 ? 90 : 0;
        dolphin?.RotateTo(Round);
      }
      if (x + dolphinRect.Width > Width || x < 0)
      {
        XDir = -XDir;
        Rotate = Rotate == 0 ? 180 : 0;
        dolphin?.RotateYTo(Rotate);
      }

      x = Math.Max(0, x);
      y = Math.Max(0, y);
      x = Math.Min(Width - dolphinRect.Width, x);
      y = Math.Min(Height - dolphinRect.Height, y);

      gameArea.SetLayoutBounds(dolphin, new Rect(x, y, dolphinRect.Width, dolphinRect.Height));
      if (Move == Tumble)
      { 
        dolphin?.RotateTo(360);
        Move = 0;
        Tumble = random.Next(20);
        XDir = -XDir;
      }
      var botRect = gameArea.GetLayoutBounds(bot);
      if (botRect.IntersectsWith(dolphinRect))
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
    }

    private void Gamepad_GamepadAdded(object sender, Gamepad e)
    {
      pad = e;
    }

    Gamepad pad;
  }
}