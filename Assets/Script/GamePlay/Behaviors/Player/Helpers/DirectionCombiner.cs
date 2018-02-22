namespace SwipeSwipeMania
{

    public class ArrowDirectionUtility
    {
        // DEFENITIOOOOONS
        private static readonly Combination[] combinations =
        {
        new Combination(ArrowDirection.up, ArrowDirection.left, ArrowDirection.upleft),
        new Combination(ArrowDirection.up, ArrowDirection.right, ArrowDirection.upright),
        new Combination(ArrowDirection.down, ArrowDirection.left, ArrowDirection.downleft),
        new Combination(ArrowDirection.down, ArrowDirection.right, ArrowDirection.downright),
        new Combination(ArrowDirection.left, ArrowDirection.right, ArrowDirection.horizontal),
        new Combination(ArrowDirection.up, ArrowDirection.down, ArrowDirection.vertical)
    };

        private struct Combination
        {
            public ArrowDirection dirA;
            public ArrowDirection dirB;
            public ArrowDirection result;

            public Combination(ArrowDirection dir1, ArrowDirection dir2, ArrowDirection result)
            {
                dirA = dir1;
                dirB = dir2;
                this.result = result;
            }
        }


        /// <summary>
        /// Return wether or not the direction is inside of a combination
        /// </summary>
        /// <returns></returns>
        public static bool IsInCombinationFor(ArrowDirection a, ArrowDirection combination)
        {
            for (int i = 0; i < combinations.Length; i++)
            {
                if (combination == combinations[i].result)
                {
                    if (a == combinations[i].dirA ||
                        a == combinations[i].dirB)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks wether or not a direction is a combination of two directions (eg, UpLeft)
        /// </summary>
        /// <returns></returns>
        public static bool IsCombination(ArrowDirection direction)
        {
            return direction == ArrowDirection.downleft ||
                   direction == ArrowDirection.downright ||
                   direction == ArrowDirection.upleft ||
                   direction == ArrowDirection.upright ||
                   direction == ArrowDirection.horizontal ||
                   direction == ArrowDirection.vertical;
        }

        /// <summary>
        /// Combines two directions to a two directional Arrow direction  (Up + Left = UpLeft)
        /// </summary>
        /// <returns></returns>
        public static ArrowDirection Combine(ArrowDirection directionA, ArrowDirection directionB)
        {
            for (int i = 0; i < combinations.Length; i++)
            {
                if (directionA == combinations[i].dirA && directionB == combinations[i].dirB)
                    return combinations[i].result;
                if (directionB == combinations[i].dirA && directionA == combinations[i].dirB)
                    return combinations[i].result;
            }
            return ArrowDirection.none;
        }
    }
}