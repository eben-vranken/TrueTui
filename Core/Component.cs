namespace TrueTui.UI_Components;

public abstract class Component
{
    // Positioning
    public int X { get; set; }
    public int Y { get; set; }
    
    // Data
    
    public ConsoleColor ForegroundColor {get; set;}
    public ConsoleColor BackgroundColor {get; set;}
    
    
    public abstract void Render(ScreenBuffer buffer);
}