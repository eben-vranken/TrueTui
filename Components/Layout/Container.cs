namespace TrueTui.UI_Components;

public class Container : Component
{
    // Data
    public List<Component> ChildrenElements { get; set; } = new();

    public override void Render(ScreenBuffer buffer)
    {
        foreach (var element in ChildrenElements)
        {
            element.Render(buffer);
        }
    }
}