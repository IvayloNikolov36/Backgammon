

using WpfBlazor.Enums;

namespace WpfBlazor.Entities;

public class Player
{
    private readonly Checker[] checkers;

    public Player(Color color, Checker[] checkers)
    {
        if (color != checkers[0].Color)
        {
            throw new ArgumentException("Wrong checkers passed!");
        }
        this.checkers = checkers;
        this.DiceRolls = 0;
        this.CheckersColor = color;
    }

    public Color CheckersColor { get; }

    public int DiceRolls { get; private set; }

    public void CastTheDice()
    {
        this.DiceRolls++;
    }
}
