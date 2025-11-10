namespace TrueTui.UI_Components;

public class Panel : Component
{
    // Positioning
    public int Width { get; set; }
    public int Height { get; set; }
    public string? Title { get; set; }
    
    // Data
    public List<Component> childrenElements { get; set; } = new();
    public BorderChars Border { get; set; }
    
    private Box border;
    
    // Constructors
    public Panel()
    {
        border = new Box();
    }
    
    public override void Render(ScreenBuffer buffer)
    {
        border.X = X;
        border.Y = Y;
        border.Width = Width;
        border.Height = Height;
        border.Title = Title;
        border.Border = Border;
        
        border.Render(buffer);

        foreach (var child in childrenElements)
        {
            child.Render(buffer);
        }
    }
}