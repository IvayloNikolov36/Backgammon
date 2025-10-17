using WpfBlazor.Entities;
using WpfBlazor.Enums;

namespace WpfBlazor.Utilities
{
    public static class CheckersPositions
    {
        private const int CheckersPosed = 15;
        private const int RosespringWhiteCheckersPoint = 24;
        private const int RosespringBlackCheckersPoint = 12;
        private const int PlakotoWhiteCheckersPoint = 24;
        private const int PlakotoBlackCheckersPoint = 1;

        private static readonly Dictionary<int, int> standardWhiteChekers = new()
            {
                {6, 5 },
                { 8, 3 },
                { 13, 5 },
                { 24, 2 }
            };

        private static readonly Dictionary<int, int> standardBlackCheckers = new()
            {
                {1, 2 },
                { 12, 5 },
                { 17, 3 },
                { 19, 5 }
            };

        public static CheckerPosition[] GetInitialPositions(
                GameVariant gameVariant,
                Color color)
        {
            return gameVariant switch
            {
                GameVariant.Standard => GetPositionsForStandard(color),
                GameVariant.Rosespring => GetPositionsForRoseSpring(color),
                GameVariant.Plakoto => GetPositionsForPlakoto(color),
                _ => throw new ArgumentException("Unhandled game variant!")
            };
        }

        private static CheckerPosition[] GetPositionsForStandard(Color color)
        {
            return color switch
            {
                Color.White => GetStandardCheckersPositions(standardWhiteChekers),
                Color.Black => GetStandardCheckersPositions(standardBlackCheckers),
                _ => throw new ArgumentException("Unhandled color type!")
            };
        }

        private static CheckerPosition[] GetPositionsForRoseSpring(Color color)
        {
            return color switch
            {
                Color.White => GetRosespringAndPlakotoCheckersPositions(RosespringWhiteCheckersPoint),
                Color.Black => GetRosespringAndPlakotoCheckersPositions(RosespringBlackCheckersPoint),
                _ => throw new ArgumentException("Unhandled color type!"),
            };
        }

        private static CheckerPosition[] GetPositionsForPlakoto(Color color)
        {
            return color switch
            {
                Color.White => GetRosespringAndPlakotoCheckersPositions(PlakotoWhiteCheckersPoint),
                Color.Black => GetRosespringAndPlakotoCheckersPositions(PlakotoBlackCheckersPoint),
                _ => throw new ArgumentException("Unhandled color type!")
            };
        }

        private static CheckerPosition[] GetStandardCheckersPositions(
            Dictionary<int, int> standardChekersCountOnPosition)
        {
            CheckerPosition[] checkerPositions = new CheckerPosition[CheckersPosed];

            int index = 0;
            foreach (KeyValuePair<int, int> item in standardChekersCountOnPosition)
            {
                int point = item.Key;
                int checkersCount = item.Value;

                for (int i = 0; i < checkersCount; i++)
                {
                    CheckerPosition x = new(point, i);
                    checkerPositions[index] = x;
                    index++;
                }
            }

            return checkerPositions;
        }

        private static CheckerPosition[] GetRosespringAndPlakotoCheckersPositions(int point)
        {
            CheckerPosition[] positions = new CheckerPosition[CheckersPosed];

            for (int i = 0; i < CheckersPosed; i++)
            {
                positions[i] = new CheckerPosition(point, i);
            }

            return positions;
        }
    }
}
