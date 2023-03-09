namespace MauiBreakout2;

/// <summary>
/// Android specific game controller code
/// </summary>
public partial class PlayerControl 
{
  /// <summary>
  /// Set to true if you have some sort of input control.
  /// </summary>
  /// <returns>true if there is a controller, false if not</returns>
  public partial bool UseGameController() => false;

  /// <summary>
  /// Implement this method to return -1.0 for the left side of the screen, 0.0 for the middle and 1.0 for the right side.
  /// </summary>
  /// <returns>-1.0 ... 1.0</returns>
  public partial double? GetX() => 0.0;
}
