using Windows.Gaming.Input;

namespace MauiBreakout2;

public partial class PlayerControl 
{
  public PlayerControl()
  {
    Gamepad.GamepadAdded += Gamepad_GamepadAdded!;
  }

  private Gamepad? Pad;

  private void Gamepad_GamepadAdded(object sender, Gamepad e)
  {
    Pad = e;
  }

  public partial double? GetX()
  {
    var reading = Pad?.GetCurrentReading();
    return reading != null ? reading?.LeftThumbstickX : null;
  }

  public partial bool UseGameController()
  {
    return true;
  }
  
}
