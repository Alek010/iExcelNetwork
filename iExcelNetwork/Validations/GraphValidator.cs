// Ignore Spelling: Validators

using iExcelNetwork.Exceptions;

namespace iExcelNetwork.Validations
{
    public static class GraphValidators
    {
        /// <summary>
        /// Validate that the number of circular edges in the graph is less than 86 to prevent a long-running process and avoid crashing Excel.
        /// </summary>
        /// <param name="circularEdgesFound">Count of circular edges in the graph.</param>
        /// <param name="circularEdgesThreshold">Set the threshold for circular edges with a default value of 85 edges.</param>
        /// <exception cref="TooManyCircularEdgesException"></exception>
        /// 
        public static void ValidateGraphCircularEdgesCount(int circularEdgesFound, int circularEdgesThreshold = 85)
        {
            if (circularEdgesFound > circularEdgesThreshold)
            {
                throw new TooManyCircularEdgesException(ExceptionMessage.GraphHasTooManyCircularEdges(circularEdgesFound, circularEdgesThreshold));
            }
        }

    }
}
