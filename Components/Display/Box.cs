namespace TrueTui.UI_Components;

public class Box : Component
{
    // Positioning
    
    public int Width { get; set; }
    public int Height { get; set; }
    
    // Data
    public string? Title { get; set; }
    public BorderChars Border { get; set; }
    
    // Constructors
    public Box()
    {
        Border = BorderChars.Single;
        ForegroundColor = Console.ForegroundColor;
        BackgroundColor = Console.BackgroundColor;
    }
    
    public Box(int x, int y, int width, int height, string? title, BorderChars? border = null,  ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Title = title;
        Border = border ??  BorderChars.Single;
        ForegroundColor = foregroundColor ?? Console.ForegroundColor;
        BackgroundColor = backgroundColor ?? Console.ForegroundColor;
    }


    public override void Render(ScreenBuffer buffer)
    {
        if (Width < 2 || Height < 2)
        {
            throw new InvalidOperationException($"Box dimensions too small: Width={Width}, Height={Height}");
        }
        
        // Render coordinates
        int y = Y;
        
        // Top of border
        string topBar = Border.TopLeft + new string(Border.Horizontal, Width - 2) + Border.TopRight;
        buffer.Write(X, y, topBar, ForegroundColor, BackgroundColor);
        y++;
        
        // Box content
        for (int i = 0; i < Height - 2; i++)
        {
            string boxLine;
            // Title
            if (i == 1 && !string.IsNullOrEmpty(Title))
            {
                boxLine = Border.Vertical + " " + Title + new string(' ', Width - 3 - Title.Length) +  Border.Vertical;
            }
            else
            {
                boxLine = Border.Vertical + new string(' ', Width - 2) + Border.Vertical;
            }

            buffer.Write(X, y, boxLine, ForegroundColor, BackgroundColor);
            y++;
        }
        
        string bottomBar = Border.BottomLeft + new string(Border.Horizontal, Width - 2) + Border.BottomRight;
        buffer.Write(X, y, bottomBar, ForegroundColor, BackgroundColor);
    }
}