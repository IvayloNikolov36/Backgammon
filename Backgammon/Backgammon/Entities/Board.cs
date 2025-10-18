namespace WpfBlazor.Entities;

public class Board
{
    private readonly Point[] points;
    private readonly Checker[] whiteCheckers;
    private readonly Checker[] darkCheckers;

    public Board(
        Point[] points,
        Checker[] whiteCheckers,
        Checker[] blackCheckers)
    {
        this.points = points;
        this.whiteCheckers = whiteCheckers;
        this.darkCheckers = blackCheckers;
    }

    public Point[] Points => [.. this.points];

    public Checker[] LightCheckers => [.. whiteCheckers];

    public Checker[] DarkCheckers => [.. darkCheckers];

    public Point GetPoint(int pointNumber)
    {
        Point? point = this.points.SingleOrDefault(p => p.Number == pointNumber);

        return point
            ?? throw new ArgumentException("Not existing point with given number!");
    }
}
