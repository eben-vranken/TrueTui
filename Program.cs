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
        
        Console.ReadKey();
    }

    static void RenderLoop(ScreenBuffer buffer)
    {
        // Define elements here
        Box outline = new Box {
            X = 0, Y = 0, 
            Width = Console.WindowWidth, Height = Console.WindowHeight, 
            Title="TrueTui Framework - Demo",
            Border = BorderChars.Ascii,
            ForegroundColor = ConsoleColor.Blue,
        };

        Panel welcomeContainer = new Panel
        {
            X = 2, Y = 4,
            Width = 45, Height = 15,
            Border = BorderChars.Double,
            ForegroundColor = ConsoleColor.Cyan,
            
            ChildrenElements =
            {
                new Label {X = 1, Y = 1, Text = "Welcome to TrueTui!", ForegroundColor = ConsoleColor.Blue},
                new Label {X = 1, Y = 2, Text = "Your components are working!", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 4, Text = "High-performance C# TUI framework with ", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 5, Text = "double-buffered rendering, full color", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 6, Text = "support, and built-in components for", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 7, Text = "creating responsive console applications", ForegroundColor = ConsoleColor.Cyan},
            }
        };

        Label currentTime = new Label { X = 1, Y = 3, ForegroundColor = ConsoleColor.Cyan};
        Label currentFrame = new Label { X = 1, Y = 4, ForegroundColor = ConsoleColor.Cyan};
        int frameCounter = 0;
        Label cpuUsage = new Label { X = 1, Y = 5, ForegroundColor = ConsoleColor.Cyan};
        Label memoryUsage = new Label { X = 1, Y = 6, ForegroundColor = ConsoleColor.Cyan};
        
        Panel systemInfoContainer = new Panel
        {
            X = 48, Y = 4,
            Width = 45, Height = 15,
            Border = BorderChars.Double,
            ForegroundColor = ConsoleColor.Cyan,
            
            ChildrenElements =
            {
                new Label {X = 1, Y = 1, Text = "System Information", ForegroundColor = ConsoleColor.Blue},
                currentTime,
                currentFrame,
                cpuUsage,
                memoryUsage,
                new Label { X = 1, Y = 7, Text = "Status: Active", ForegroundColor = ConsoleColor.Cyan }
            }
        };

        Panel aboutPanel = new Panel
        {
            X = 2, Y = 19,
            Width = 91, Height = 13,
            Border = BorderChars.Rounded,
            ForegroundColor = ConsoleColor.Cyan,
            
            ChildrenElements =
            {
                // Left
                new Label {X = 1, Y = 1, Text = "About TrueTui", ForegroundColor = ConsoleColor.Blue},
                new Label {X = 1, Y = 3, Text = "Features:", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 4, Text = "\t - Double-buffered rendering (no flicker)", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 5, Text = "\t - Component-based architecture", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 6, Text = "\t - Nested layouts with Panels", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 6, Text = "\t - Multiple border styles", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 7, Text = "\t - Custom color scheme per component", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 8, Text = "\t - Relative positioning", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 1, Y = 9, Text = "\t - Minimal memory footprint", ForegroundColor = ConsoleColor.Cyan},
                
                // Right
                new Label {X = 48, Y = 3, Text = "Why TrueTui:", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 48, Y = 4, Text = "\t - No external dependencies", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 48, Y = 5, Text = "\t - Cross-platform console support", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 48, Y = 6, Text = "\t - Efficient screen updates", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 48, Y = 6, Text = "\t - Perfect for CLI tools & dashboards", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 48, Y = 7, Text = "\t - Beginner-friendly API design", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 48, Y = 8, Text = "\t - Build professional TUIs in minutes", ForegroundColor = ConsoleColor.Cyan},
                new Label {X = 48, Y = 9, Text = "\t - Easily create custom components", ForegroundColor = ConsoleColor.Cyan},

            }
        };
        
        while (true)
        {
            // Render elements here
            outline.Render(buffer);
            welcomeContainer.Render(buffer);
            
            currentTime.Text = DateTime.Now.ToLongTimeString();
            currentFrame.Text = $"Current Frame: {frameCounter++}";
            cpuUsage.Text = $"CPU Usage - {Process.GetCurrentProcess().TotalProcessorTime}";
            memoryUsage.Text = $"Memory Usage - {GC.GetTotalMemory(false)}";
            systemInfoContainer.Render(buffer);
            
            aboutPanel.Render(buffer);
            // Render the buffer
            buffer.Render();
            
            // Frame stop
            Thread.Sleep(frameDelay);

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                break;
        }
    }
}