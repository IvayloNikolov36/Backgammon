using WpfBlazor.Entities;
using WpfBlazor.Enums;
using WpfBlazor.Utilities;
using static WpfBlazor.Constants.StyleConstants;

namespace WpfBlazor;

public partial class Backgammon
{
    private Board? board;

    private Checker? selectedChecker = null;

    public Backgammon()
    {
        GameVariant variant = GameVariant.Rosespring;

        Checker[] lightCheckers = CheckersPositions
            .GetInitialPositions(variant, Color.White);

        Checker[] darkCheckers = CheckersPositions
            .GetInitialPositions(variant, Color.Black);

        Point[] points = ConstructPoints(lightCheckers, darkCheckers);

        this.board = new(points, lightCheckers, darkCheckers);

        Game game = new(
            variant,
            [
                new Player(Color.White, lightCheckers),
                new Player(Color.Black, darkCheckers)
            ],
            this.board);
    }
   
    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
    
    private void ClickChecker(Checker checker)
    {
        int pointNumber = checker.PointNumber;
        Point point = this.board!.Points
            .First(p => p.Number == pointNumber);

        Checker checkerToMove = point.Checkers
            .Where(ch => ch.Color == checker.Color)
            .OrderByDescending(ch => ch.PointIndex)
            .First();

        this.selectedChecker = checkerToMove;
    }

    private void SelectPoint(Point point)
    {
        if (this.selectedChecker is null)
        {
            return;
        }

        if (this.selectedChecker.PointNumber == point.Number)
        {
            return;
        }

        // TODO: change the rule based on different games
        // TODO: validate whether it can be placed based on the path and the dice combination...
        if (!point.Checkers.Any() || point.Checkers.First().Color == this.selectedChecker.Color)
        {
            int sourcePoint = this.selectedChecker.PointNumber;
            this.board!.GetPoint(sourcePoint).RemoveChecker();

            point.PlaceChecker(this.selectedChecker);
            this.selectedChecker = null;
        }
    }

    private Point[] ConstructPoints(Checker[] lightCheckers, Checker[] darkCheckers)
    {
        Point[] boardPoints = new Point[24];
        // TODO: const

        for (int i = 1; i <= boardPoints.Length; i++)
        {
            IEnumerable<Checker> pointCheckers = lightCheckers.Where(c => c.PointNumber == i)
                .Concat(darkCheckers.Where(c => c.PointNumber == i));

            Point point = new(i, pointCheckers);
            boardPoints[i - 1] = point;
        }

        return boardPoints;
    }

    private static string GetPointStyle(int index, PointSide pointSide)
    {
        string pointSideStyle = pointSide == PointSide.Up ? PointUpClass : PointDownClass;
        string pointColorStyle = index % 2 == 0 ? DarkPointClass : LightPointClass;

        return $"{pointSideStyle} {pointColorStyle}";
    }

    private static string GetCheckerStyle(Color color)
    {
        return color == Color.White ? LightCheckerClass : DarkCheckerClass;
    }

    private static int[] LeftTopPoints() => [.. Enumerable.Range(13, 6)];
    private static int[] LeftDownPoints() => [.. Enumerable.Range(7, 6).Reverse()];
    private static int[] RightTopPoints() => [.. Enumerable.Range(19, 6)];
    private static int[] RightBottomPoints() => [.. Enumerable.Range(1, 6).Reverse()];
}
