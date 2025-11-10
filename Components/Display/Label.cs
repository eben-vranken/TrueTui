namespace TrueTui.UI_Components;

public class Label : Component
{
    
    // Data
    public string Text {get; set;}
    
    // Constructors
    public Label() {}
    
    public Label(int x, int y, string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
    {
        X = x;
        Y = y;
        Text = text;
        ForegroundColor = foregroundColor ??  Console.ForegroundColor;
        BackgroundColor = backgroundColor ??  Console.ForegroundColor;
    }

    public override void Render(ScreenBuffer buffer)
    {
        buffer.Write(X, Y, Text, ForegroundColor, BackgroundColor);
    }
}