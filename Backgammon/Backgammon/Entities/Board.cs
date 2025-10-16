namespace WpfBlazor.Entities;

public class Board
{
    private readonly CheckerPosition[] whiteCheckersPositions;
    private readonly CheckerPosition[] blackCheckersPositions;

    public Board(
        CheckerPosition[] whiteCheckersPositions,
        CheckerPosition[] blackCheckersPositions)
    {
        this.whiteCheckersPositions = whiteCheckersPositions;
        this.blackCheckersPositions = blackCheckersPositions;
    }

    public CheckerPosition[] WhiteCheckersPositions => [.. whiteCheckersPositions];

    public CheckerPosition[] BlackCheckersPositions => [.. blackCheckersPositions];
}
