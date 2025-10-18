using WpfBlazor.Enums;

namespace WpfBlazor.Entities;

public class Checker
{
    private int pointNumber;
    private int pointIndex;

    public Checker(Color color, int pointNumber, int pointIndex)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Color = color;
        this.pointNumber = pointNumber;
        this.pointIndex = pointIndex;
    }

    public string Id { get; }

    public Color Color { get; }

    public int PointNumber => this.pointNumber;

    public int PointIndex => this.pointIndex;

    public void UpdatePointIndex (int newIndex)
    {
        this.pointIndex = newIndex;
    }

    public void UpdatePoint(int pointNumber)
    {
        this.pointNumber = pointNumber;
    }
}
