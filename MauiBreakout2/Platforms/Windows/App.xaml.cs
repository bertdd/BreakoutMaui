﻿using Windows.Gaming.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MauiBreakout2.WinUI
{
  /// <summary>
  /// Provides application-specific behavior to supplement the default Application class.
  /// </summary>
  public partial class App : MauiWinUIApplication
  {
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
      InitializeComponent();
      Gamepad.GamepadAdded += Gamepad_GamepadAdded!;
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public Gamepad? Pad;

    private void Gamepad_GamepadAdded(object sender, Gamepad e)
    {
      Pad = e;
    }
  }
}