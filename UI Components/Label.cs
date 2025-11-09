namespace TrueTui.UI_Components;

public class Label
{
    // Positioning
    public int X { get; set; }
    public int Y { get; set; }
    
    // Data
    public string Text {get; set;}
    public ConsoleColor ForegroundColor {get; set;}
    public ConsoleColor BackgroundColor {get; set;}
    
    public Label(int x, int y, string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
    {
        X = x;
        Y = y;
        Text = text;
        ForegroundColor = foregroundColor ??  Console.ForegroundColor;
        BackgroundColor = backgroundColor ??  Console.ForegroundColor;
    }

    public void Render(ScreenBuffer buffer)
    {
        buffer.Write(X, Y, Text, ForegroundColor, BackgroundColor);
    }
}