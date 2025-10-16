

using WpfBlazor.Enums;

namespace WpfBlazor.Entities;

public class Player
{
    private readonly Checker[] checkers;

    public Player(Color color)
    {
        this.checkers = new Checker[15];
        for (int i = 0; i < 15; i++)
        {
            this.checkers[i] = new Checker(color);
        }

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
