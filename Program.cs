using System.Diagnostics;
using TrueTui.UI_Components;

namespace TrueTui;

class Program
{
    public static int TargetFPS { get; set; } = 60;
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        ScreenBuffer buffer = new ScreenBuffer();

        RenderLoop(buffer);
    }

    static void RenderLoop(ScreenBuffer buffer)
    {
        int frameDelay = 1000 / 60;
            
        Box box = new Box(1, 1, 
                    25, 10, 
                    "Box!", 
                    BorderChars.Ascii);
        
        Label label = new Label(1, 12, "New Label!");
        Label specsLabel = new Label(1, 15, "", ConsoleColor.Cyan);

        var currentProcess = Process.GetCurrentProcess();
        int frameCount = 0;
        
        Box box2 = new Box(27, 1,
            25, 10,
            "Box!",
            BorderChars.Double);
        
        while (true)
        {
            box.Render(buffer);
            box2.Render(buffer);
            
            label.Render(buffer);
            
            long memoryMB = currentProcess.WorkingSet64 / (1024 * 1024);
            int threadCount = currentProcess.Threads.Count;
            specsLabel.Text = $"RAM: {memoryMB} MB | Threads: {threadCount} | Frames: {frameCount} | {DateTime.Now:HH:mm:ss}";
            
            specsLabel.Render(buffer);

            buffer.Render();
            
            frameCount++;
            Thread.Sleep(frameDelay);

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                break;
        }
    }
}