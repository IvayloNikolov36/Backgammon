using WpfBlazor.Enums;

namespace WpfBlazor.Entities;

public class Game
{
    private readonly Player[] players;

    public Game(GameVariant variant, Player[] players, Board board)
    {
        this.Variant = variant;
        this.Board = board;

        if (players.Length != 2)
        {
            throw new ArgumentException("Invalid players count!");
        }

        this.players = players;
    }

    public GameVariant Variant { get; }

    public Board Board { get; }

    // Result, Time...
}
