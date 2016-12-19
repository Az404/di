using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.Preprocessors
{
    public class LowerCasePreprocessor : IWordsPreprocessor
    {
        public IEnumerable<string> ProcessWords(IEnumerable<string> words)
        {
            return words.Select(word => word.ToLower());
        }
    }
}