namespace TrueTui.UI_Components;

public class Panel : Component
{
    // Positioning
    public int Width { get; set; }
    public int Height { get; set; }
    public string? Title { get; set; }
    
    // Data
    public List<Component> ChildrenElements { get; set; } = new();
    public BorderChars Border { get; set; }
    
    private Box border;
    
    // Constructors
    public Panel()
    {
        border = new Box();
        ChildrenElements = new List<Component>();
    }
    
    public override void Render(ScreenBuffer buffer)
    {
        border.X = X;
        border.Y = Y;
        border.Width = Width;
        border.Height = Height;
        border.Title = Title;
        border.Border = Border;
        border.ForegroundColor = ForegroundColor;
        border.BackgroundColor = BackgroundColor;
        
        border.Render(buffer);

        foreach (var child in ChildrenElements)
        {
            int originalX = child.X;
            int originalY = child.Y;

            child.X = X + originalX + 1;
            child.Y = Y + originalY + 1;
            
            child.Render(buffer);
            
            child.X = originalX;
            child.Y = originalY;
        }
    }
}