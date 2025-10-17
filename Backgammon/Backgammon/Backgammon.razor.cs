using WpfBlazor.Entities;
using WpfBlazor.Enums;
using WpfBlazor.Utilities;
using static WpfBlazor.Constants.StyleConstants;

namespace WpfBlazor;

public partial class Backgammon
{
    private Board? board;

    public Backgammon()
    {
        GameVariant variant = GameVariant.Standard;

        CheckerPosition[] whiteCheckersPositions = CheckersPositions
            .GetInitialPositions(variant, Color.White);

        CheckerPosition[] blackCheckersPositions = CheckersPositions
            .GetInitialPositions(variant, Color.Black);

        this.board = new(whiteCheckersPositions, blackCheckersPositions);

        Game game = new(
            variant,
            [new Player(Color.White), new Player(Color.Black)],
            this.board);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    private int GetWhiteCheckersCount(int pointNumber)
    {
        return this.board!.WhiteCheckersPositions
            .Count(p => p.PointNumber == pointNumber);
    }

    private int GetBlackCheckersCount(int pointNumber)
    {
        return this.board!.BlackCheckersPositions
            .Count(p => p.PointNumber == pointNumber);
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
