namespace WpfBlazor.Entities;

public class CheckerPosition
{
    public CheckerPosition(int pointNumber, int pointIndex)
    {
        this.PointNumber = pointNumber;
        this.PointIndex = pointIndex;
    }

    public int PointNumber { get; }

    public int PointIndex { get; }
}
