namespace TrueTui.UI_Components;

public class Box
{
    // Positioning
    public int X { get; set; }
    public int Y { get; set; }
    
    public int Width { get; set; }
    public int Height { get; set; }
    
    // Data
    public string? Title { get; set; }
    public BorderChars Border { get; set; }
    public ConsoleColor ForegroundColor {get; set;}
    public ConsoleColor BackgroundColor {get; set;}
    
    // Constructors
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


    public void Render(ScreenBuffer buffer)
    {
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