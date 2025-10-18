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

        public static Checker[] GetInitialPositions(
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

        private static Checker[] GetPositionsForStandard(Color color)
        {
            return color switch
            {
                Color.White => GetStandardCheckersPositions(
                    standardWhiteChekers,
                    color),
                Color.Black => GetStandardCheckersPositions(
                    standardBlackCheckers,
                    color),
                _ => throw new ArgumentException("Unhandled color type!")
            };
        }

        private static Checker[] GetPositionsForRoseSpring(Color color)
        {
            return color switch
            {
                Color.White => GetRosespringAndPlakotoCheckersPositions(
                    RosespringWhiteCheckersPoint,
                    color),
                Color.Black => GetRosespringAndPlakotoCheckersPositions(
                    RosespringBlackCheckersPoint,
                    color),
                _ => throw new ArgumentException("Unhandled color type!"),
            };
        }

        private static Checker[] GetPositionsForPlakoto(Color color)
        {
            return color switch
            {
                Color.White => GetRosespringAndPlakotoCheckersPositions(
                    PlakotoWhiteCheckersPoint,
                    color),
                Color.Black => GetRosespringAndPlakotoCheckersPositions(
                    PlakotoBlackCheckersPoint,
                    color),
                _ => throw new ArgumentException("Unhandled color type!")
            };
        }

        private static Checker[] GetStandardCheckersPositions(
            Dictionary<int, int> standardChekersCountOnPosition,
            Color color)
        {
            Checker[] checkerPositions = new Checker[CheckersPosed];

            int index = 0;
            
            foreach (KeyValuePair<int, int> item in standardChekersCountOnPosition)
            {
                int point = item.Key;
                int checkersCount = item.Value;

                for (int i = 0; i < checkersCount; i++)
                {
                    Checker x = new(color, point, i);
                    checkerPositions[index] = x;
                    index++;
                }
            }

            return checkerPositions;
        }

        private static Checker[] GetRosespringAndPlakotoCheckersPositions(
            int point,
            Color color)
        {
            Checker[] positions = new Checker[CheckersPosed];

            for (int i = 0; i < CheckersPosed; i++)
            {
                positions[i] = new Checker(color, point, i);
            }

            return positions;
        }
    }
}
