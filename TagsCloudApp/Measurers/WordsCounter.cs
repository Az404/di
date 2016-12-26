using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.Measurers
{
    public class WordsCounter : IWordsMeasurer
    {
        public Result<IEnumerable<MeasuredWord>> MeasureWords(IEnumerable<string> words)
        {
            var wordStats = words.GroupBy(word => word).ToArray();
            var maxCount = wordStats.Length > 0 ? wordStats.Max(group => group.Count()) : 1;
            return Result.Of<IEnumerable<MeasuredWord>>(() =>
                        wordStats
                            .Select(group => new MeasuredWord(group.Key, group.Count()/(double) maxCount))
                            .ToArray()
                )
                .RefineError("Can't measure words by the number");
        }
    }
}