using WpfBlazor.Entities;
using WpfBlazor.Enums;
using WpfBlazor.Utilities;

namespace WpfBlazor;

public partial class Backgammon
{
    private Board? board;

    public Backgammon()
    {
        GameVariant variant = GameVariant.Rosespring;

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

    }
}
