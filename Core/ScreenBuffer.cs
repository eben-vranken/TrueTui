namespace TrueTui;

public class ScreenBuffer
{
    private char[,] buffer;
    private char[,] previousBuffer;
    private ConsoleColor[,] foregroundBuffer;
    private ConsoleColor[,] backgroundBuffer;
    private ConsoleColor[,] previousForegroundBuffer;
    private ConsoleColor[,] previousBackgroundBuffer;    
    
    private int width;
    private int height;

    public ScreenBuffer(int? width = null, int? height = null)
    {
        this.width = width ?? Console.WindowWidth;
        this.height = height ?? Console.WindowHeight;
    
        buffer = new char[this.height, this.width];
        previousBuffer = new char[this.height, this.width];
        foregroundBuffer = new ConsoleColor[this.height, this.width];
        backgroundBuffer = new ConsoleColor[this.height, this.width];
        previousForegroundBuffer = new ConsoleColor[this.height, this.width];
        previousBackgroundBuffer = new ConsoleColor[this.height, this.width];
        
        Console.CursorVisible = false;
    
        Clear();
    }
    
    
    public void Clear()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                buffer[y, x] = ' ';
                foregroundBuffer[y, x] = ConsoleColor.Gray;
                backgroundBuffer[y, x] = ConsoleColor.Black;
            }
        }
    }

    public void Write(int x, int y, string text, ConsoleColor? fg = null, ConsoleColor? bg = null)
    {
        if (y < 0 || y >= height) return;
        
        ConsoleColor foreground = fg ?? Console.ForegroundColor;
        ConsoleColor background = bg ?? Console.BackgroundColor;
        
        for (int i = 0; i < text.Length && x + i < width; i++)
        {
            if (x + i < 0) continue;
            
            buffer[y, x + i] = text[i];
            foregroundBuffer[y, x + i] = foreground;
            backgroundBuffer[y, x + i] = background;
        }
    }

    public void Render()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Only redraw cells that changed
                if (buffer[y, x] != previousBuffer[y, x] ||
                    foregroundBuffer[y, x] != previousForegroundBuffer[y, x] ||
                    backgroundBuffer[y, x] != previousBackgroundBuffer[y, x])
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = foregroundBuffer[y, x];
                    Console.BackgroundColor = backgroundBuffer[y, x];
                    Console.Write(buffer[y, x]);
                    
                    previousBuffer[y, x] = buffer[y, x];
                    previousForegroundBuffer[y, x] = foregroundBuffer[y, x];
                    previousBackgroundBuffer[y, x] = backgroundBuffer[y, x];
                }
            }
        }
        
        Console.ResetColor();
        Console.SetCursorPosition(0, 0);
    }
}