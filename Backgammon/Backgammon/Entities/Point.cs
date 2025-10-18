namespace WpfBlazor.Entities;

public class Point
{
    private readonly List<Checker> checkers;

    public Point(int number, IEnumerable<Checker> checkers)
    {
        this.Number = number;
        this.checkers = [.. checkers];
    }

    public int Number { get; }

    public IEnumerable<Checker> Checkers => [.. this.checkers];

    public void PlaceChecker(Checker checker)
    {
        int lastCheckerIndex = - 1;

        if (this.checkers.Count > 0)
        {
            lastCheckerIndex = this.checkers.Last().PointIndex;
        }

        // TODO: mull over
        checker.UpdatePoint(this.Number);
        checker.UpdatePointIndex(lastCheckerIndex + 1);

        this.checkers.Add(checker);
    }

    public Checker RemoveChecker()
    {
        var checkerToRemove = this.checkers.Last()
            ?? throw new ArgumentException("The checker is not placed on this point!");

        this.checkers.Remove(checkerToRemove);

        return checkerToRemove;
    }
}
