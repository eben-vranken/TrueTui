namespace TrueTui.UI_Components;

public class Container : Component
{
    // Data
    public List<Component> childrenElements { get; set; } = new();

    public override void Render(ScreenBuffer buffer)
    {
        foreach (var element in childrenElements)
        {
            element.Render(buffer);
        }
    }
}