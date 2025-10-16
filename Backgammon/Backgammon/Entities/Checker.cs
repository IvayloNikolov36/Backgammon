
using WpfBlazor.Enums;

namespace WpfBlazor.Entities;

public class Checker
{
    public Checker(Color color)
    {
        this.Color = color;
    }

    public Color Color { get; }

    public int PointPosition { get; set; }

    public int PointOrder { get; set; }
}
