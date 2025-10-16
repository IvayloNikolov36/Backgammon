using WpfBlazor.Entities;
using WpfBlazor.Enums;

namespace WpfBlazor.Utilities
{
    public static class CheckersPositions
    {
        private const int RosespringCheckersPosed = 15;
        private const int RosespringWhiteCheckersPoint = 24;
        private const int RosespringBlackCheckersPoint = 12;
        public static CheckerPosition[] GetInitialPositions(GameVariant gameVariant, Color color)
        {
            return gameVariant switch
            {
                GameVariant.Standard => throw new NotImplementedException("This game type is still not implemented"),
                GameVariant.Rosespring => GetPositionsForRoseSpring(color),
                GameVariant.Plakoto => throw new NotImplementedException("This game type is still not implemented"),
                _ => throw new ArgumentException("Unhandled game variant"),
            };
        }

        private static CheckerPosition[] GetPositionsForRoseSpring(Color color)
        {
            return color switch
            {
                Color.White => GetRosespringCheckersPositions(RosespringWhiteCheckersPoint),
                Color.Black => GetRosespringCheckersPositions(RosespringBlackCheckersPoint),
                _ => throw new ArgumentException("Unhandled color type!"),
            };
        }

        private static CheckerPosition[] GetRosespringCheckersPositions(int point)
        {
            CheckerPosition[] positions = new CheckerPosition[RosespringCheckersPosed];

            for (int i = 0; i < RosespringCheckersPosed; i++)
            {
                positions[i] = new CheckerPosition(point, i);
            }

            return positions;
        }
    }
}
