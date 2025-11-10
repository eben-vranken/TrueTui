using System.Diagnostics;
using TrueTui.UI_Components;

namespace TrueTui;

class Program
{
    public static int TargetFPS { get; set; } = 60;
    public static int frameDelay { get; set; } = 1000 / TargetFPS;
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        ScreenBuffer buffer = new ScreenBuffer();

        RenderLoop(buffer);
    }

    static void RenderLoop(ScreenBuffer buffer)
    {
        // Define elements here
        Container header = new Container
        {
            childrenElements =
            {
                // Border
                new Box { X = 0, Y = 0, Width = 65, Height = 15},
                
                new Label { X = 2, Y = 2, Text = "Box Title", ForegroundColor = ConsoleColor.Cyan},
                new Label { X = 2, Y = 3, Text = "Box Content", ForegroundColor = ConsoleColor.DarkCyan},
                new Label { X = 2, Y = 4, Text = "Box Text", ForegroundColor = ConsoleColor.DarkCyan},
                new Label { X = 2, Y = 5, Text = "Box Text", ForegroundColor = ConsoleColor.DarkCyan},
            }
        };

        Container overflowTest = new Container()
        {
            childrenElements =
            {
                // Border
                new Box { X = 0, Y = 17, Width = 10, Height = 5 },
                new Label
                {
                    X = 2, Y = 18, Text = "This is an overflow test to see what will happen when I overflow",
                    ForegroundColor = ConsoleColor.Cyan
                },
            }
        };
        
        while (true)
        {
            // Render elements here
            header.Render(buffer);
            
            overflowTest.Render(buffer);
            
            // Render the buffer
            buffer.Render();
            
            // Frame stop
            Thread.Sleep(frameDelay);

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                break;
        }
    }
}