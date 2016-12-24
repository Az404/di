using System.Collections.Generic;
using System.Linq;
using ResultOf;

namespace TagsCloudVisualization.Preprocessors
{
    public class LowerCasePreprocessor : IWordsPreprocessor
    {
        public Result<IEnumerable<string>> ProcessWords(IEnumerable<string> words)
        {
            return Result.Ok(words.Select(word => word.ToLower()));
        }
    }
}